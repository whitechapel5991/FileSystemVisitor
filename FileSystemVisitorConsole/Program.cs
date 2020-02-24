using FileSystemVisitor;
using System;
using System.IO;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static readonly string Path = @"d:\проги_дес\музыка\";
        static void Main(string[] args)
        {
            Console.WriteLine($"Root path is {Path}:");
            if (Directory.Exists(Path))
            {
                var visitor = 
                    new FileSystemVisitor.FileSystemVisitor();
                var visitor2 =
                    new FileSystemVisitor.FileSystemVisitor(() => "Sagath*");

                visitor.Progress += ConsoleLog;
                visitor2.Progress += ConsoleLog;

                var rootFolder =
                    new FileSystemVisitor.Entities.Folder(Path);
                
                visitor.StartBuildSystemTree(rootFolder);

                foreach (var item in visitor.GetAllFoldersAndFiles(rootFolder))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("=======================================================================");

                rootFolder =
                    new FileSystemVisitor.Entities.Folder(Path);
                visitor2.StartBuildSystemTree(rootFolder);
                foreach (var item in visitor2.GetAllFoldersAndFiles(rootFolder))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Warring. Directory does not exist!");
            }

        }

        public static void ConsoleLog(object sender, ProgressArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}
