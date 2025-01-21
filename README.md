# JavaMainClassFinder

该命令行工具用于查找指定目录下所有.jar文件中位于META-INF/MANIFEST.MF中的Main-Class字段内容，并输出到程序根目录下的result.txt与result.csv文件中。

本工具是作者为了编写[LSL](https://github.com/Orange-Icepop/LSL)的Minecraft服务端核心校验功能而临时做的一个分析小程序，因此代码比较简单，没有做太多的优化。

可以使用以下命令行参数来运行该程序：

- -d（或--directory） 指定要查找的目录
- -h（或--help） 寻求帮助

-d与--directory参数后面需要跟一个目录路径，该目录下会递归查找所有.jar文件。

堪用，勿喷。

## English description

This command line tool is used to find the contents of the Main-Class field in the META-INF/MANIFEST.MF file in all .jar files in the specified directory, and output them to the result.txt and result.csv files in the program root directory.

This tool is a temporary analysis applet made by the author to write the Minecraft server core verification function of [LSL](https://github.com/Orange-Icepop/LSL). Therefore, the code is relatively simple and not optimized much.

You can run the program using the following command line parameters:

- -d (or --directory) specifies the directory to search
- -h (or --help) for help

The -d and --directory parameters need to be followed by a directory path, and all .jar files in the directory will be recursively searched.

Just can be used, don't spray.
