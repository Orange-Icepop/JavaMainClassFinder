# JavaMainClassFinder

该命令行工具用于查找指定目录下所有.jar文件中位于META-INF/MANIFEST.MF中的Main-Class字段内容，并输出到程序根目录下的result.txt与result.csv文件中。

本工具是作者为了编写LSL的Minecraft服务端核心校验功能而临时做的一个分析小程序，因此代码比较简单，没有做太多的优化。

可以使用以下命令行参数来运行该程序：

- -d（或--directory） 指定要查找的目录
- -h（或--help） 寻求帮助

-d与--directory参数后面需要跟一个目录路径，该目录下会递归查找所有.jar文件。

堪用，勿喷。
