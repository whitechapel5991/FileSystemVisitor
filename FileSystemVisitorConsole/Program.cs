using FileSystemVisitor;
using System;
using System.IO;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static readonly string Path = @"d:\проги_дес\музыка\";
        static void Main()
        {
            Console.WriteLine($"Root path is {Path}:");
            if (Directory.Exists(Path))
            {
                var visitor =
                    new FileSystemVisitor.FileSystemVisitor(() => "Reflection*");

                visitor.Start += ConsoleLog;
                visitor.Finish += ConsoleLog;
                visitor.DirectoryFinished += ConsoleLog;
                visitor.FileFinished += ConsoleLog;
                visitor.FilteredDirectoryFinished += ConsoleLog;
                visitor.FilteredFileFinished += ConsoleLog;

                foreach (var item in visitor.Find(Path))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                foreach (var item in visitor.FindWithFilter(Path))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("Stop searching after five finded elements:");
                int iterateCount = 5;
                int curentIterate = 0;
                foreach (var item in visitor.Find(Path))
                {
                    curentIterate++;
                    Console.WriteLine(item);
                    if (curentIterate == iterateCount)
                    {
                        visitor.Stop();
                    }
                }


                Console.WriteLine();
                Console.WriteLine("Exclude files from search:");

                visitor.ExcludeFilesFromSearch();
                foreach (var item in visitor.Find(Path))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("Exclude folders from search:");

                visitor.ExcludeFoldersFromSearch();
                foreach (var item in visitor.Find(Path))
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
