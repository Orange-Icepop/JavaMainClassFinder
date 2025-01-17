using System;
using System.IO.Compression;
namespace JavaMainClassFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? path = null;
            if (args != null && args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == "-h" || arg == "--help")
                    {
                        Console.WriteLine("Usage: JavaMainClassFinder.exe -d(or --directory) [directory]");
                        Console.WriteLine("Or, you can enter the directory after running the program.");
                        return;
                    }
                    else if (arg.StartsWith("-d") || arg.StartsWith("--directory"))
                    {
                        path = args[1];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid argument: " + arg);
                        Console.WriteLine("Please use -h or --help for help.");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter the path of the directory: ");
                path = Console.ReadLine();
            }
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("please enter a valid path");
            }
            else if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory does not exist");
            }
            else
            {
                Dictionary<string,string> dict = new();
                string[] files = Directory.GetFiles(path, "*.jar", SearchOption.AllDirectories);
                Console.WriteLine("Found " + files.Length + " jar files");
                foreach (string file in files)
                {
                    string? mainClass = GetMainClass(file);
                    if (mainClass == null)
                    {
                        Console.WriteLine("No Main-Class found in " + file);
                        dict.Add(file, "No Main-Class found");
                    }
                    else if (mainClass.StartsWith("Access") || mainClass.StartsWith("IO") || mainClass.StartsWith("Error")) dict.Add(file, mainClass);
                    else
                    {
                        Console.WriteLine("Main-Class found in " + file + ": " + mainClass);
                        dict.Add(file, mainClass);
                    }
                }
                string result = string.Join(Environment.NewLine, dict.Select(kvp => $"{kvp.Key}:{kvp.Value}"));
                File.WriteAllText("result.txt", result);
                Console.WriteLine("Results saved to result.txt");
                string csv = string.Join(Environment.NewLine, dict.Select(kvp => $"{kvp.Key}, {kvp.Value}"));
                File.WriteAllText("result.csv", csv);
                Console.WriteLine("Results saved to result.csv");

            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            return;
        }
        public static string? GetMainClass(string jarFilePath)
        {
            try
            {
                using FileStream stream = new FileStream(jarFilePath, FileMode.Open);
                using ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read);
                ZipArchiveEntry? manifestEntry = archive.Entries.FirstOrDefault(entry => entry.FullName == "META-INF/MANIFEST.MF");
                if (manifestEntry != null)
                {
                    using StreamReader reader = new StreamReader(manifestEntry.Open());
                    string manifestContent = reader.ReadToEnd();
                    return FindMainClassLine(manifestContent);
                }
                return null;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied: " + ex.Message);
                return "Access denied: " + ex.Message;
            }
            catch (IOException ex)
            {
                Console.WriteLine("IO error: " + ex.Message);
                return "Error reading file: " + ex.Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading jar file: " + ex.Message);
                return "Error reading jar file: " + ex.Message;
            }
        }

        public static string? FindMainClassLine(string manifestContent)
        {
            string[] lines = manifestContent.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.StartsWith("Main-Class:"))
                {
                    return line.Substring("Main-Class:".Length).Trim();
                }
            }
            return null;
        }
    }
}
