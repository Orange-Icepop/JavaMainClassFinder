# JavaMainClassFinder

该命令行工具用于查找指定目录下所有.jar文件中位于META-INF/MANIFEST.MF中的Main-Class字段内容，并输出到程序根目录下的result.txt与result.csv文件中。

本工具是作者为了编写LSL的Minecraft服务端核心校验功能而临时做的一个分析小程序，因此代码比较简单，没有做太多的优化。

并且，也不支持直接通过命令行参数指定要查找的目录，只能在程序运行后手动输入。
