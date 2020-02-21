using System;
using System.IO;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static readonly string Path = @"d:\TKMI\";
        static void Main(string[] args)
        {
            Console.WriteLine($"Root path is {Path}:");
            if (Directory.Exists(Path))
            {
                var visitor = 
                    new FileSystemVisitor.FileSystemVisitor();
                var visitor2 =
                    new FileSystemVisitor.FileSystemVisitor(() => "*.*");
                
                var rootFolder =
                    new FileSystemVisitor.Entities.Folder(Path);
                
                visitor.BuildFileSystemTree(rootFolder);

                foreach (var item in visitor.GetAllFoldersAndFiles(rootFolder))
                {
                    Console.WriteLine(item);
                }

                visitor2.BuildFileSystemTree(rootFolder);
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
    }
}
