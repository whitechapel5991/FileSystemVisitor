using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemVisitorTest.FakeFileSystem
{
    class FileSystem
    {
        protected string CurrentDirectory { get; private set; } = Environment.CurrentDirectory;
        public void InitFakeFileSystem()
        {
            DeleteFakeFileSystem();

            foreach (var folder in GetFolderElements())
            {
                string path = Path.Combine(CurrentDirectory, folder);
                Directory.CreateDirectory(path);
            }

            foreach (var file in GetFileElements())
            {
                string path = Path.Combine(CurrentDirectory, file);
                File.Create(path);
            }
        }

        public string GetRootFolderPath()
        {
            return Path.Combine(CurrentDirectory, GetFolderElements()[0]);
        }

        private void DeleteFakeFileSystem()
        {
            string path = GetRootFolderPath();

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        private string[] GetFolderElements()
        {
            return new string[]
            {
                @"rootTree\",
                @"rootTree\folder1",
                @"rootTree\folder2",
                @"rootTree\folder1\folder11",
                @"rootTree\folder1\folder12",
            };
        }

        private string[] GetFileElements()
        {
            return new string[]
            {
                @"rootTree\123.docx",
                @"rootTree\123.txt",
                @"rootTree\1.bat",
                @"rootTree\2.bat",
                @"rootTree\3.bat",
                @"rootTree\temp.txt",
                @"rootTree\folder1\folder1text.txt",
                @"rootTree\folder1\folder1text2.txt",
                @"rootTree\folder1\folder1text3.txt",
                @"rootTree\folder2\folder1docx.docx",
                @"rootTree\folder2\folder1docx2.docx",
                @"rootTree\folder2\folder1docx3.docx",
                @"rootTree\folder1\folder11\1.bat",
                @"rootTree\folder1\folder11\2.bat",
                @"rootTree\folder1\folder11\3.bat",
                @"rootTree\folder1\folder11\4.bat",
                @"rootTree\folder1\folder12\1.bmp",
                @"rootTree\folder1\folder12\2.bmp",
                @"rootTree\folder1\folder12\3.bmp",
                @"rootTree\folder1\folder12\4.bmp",
            };
        }
    }
}
