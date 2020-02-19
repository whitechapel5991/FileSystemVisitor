using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor
{
    public class FileSystemVisitor
    {
        public IEnumerable<string> GetFileTree(string path)
        {
            if (Directory.Exists(path))
            {
                var folders = Directory.GetDirectories(path);
                var files = Directory.GetFiles(path);
            }
            foreach(var item in Directory.EnumerateFileSystemEntries(path))
            {
                 yield return item;
            }
        }
    }
}
