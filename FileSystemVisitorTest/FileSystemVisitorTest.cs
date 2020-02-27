using FileSystemVisitor;
using FileSystemVisitorTest.FakeFileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Visitor = FileSystemVisitor.FileSystemVisitor;

namespace FileSystemVisitorTest
{
    public class Tests
    {
        private Visitor visitor;
        private FileSystem system;

        [OneTimeSetUp]
        public void Setup()
        {
            system = new FileSystem();
            system.InitFakeFileSystem();

            visitor = new Visitor(() => "*.bat");
            visitor.Start += ConsoleLog;
            visitor.Finish += ConsoleLog;
            visitor.DirectoryFinished += ConsoleLog;
            visitor.FileFinished += ConsoleLog;
            visitor.FilteredDirectoryFinished += ConsoleLog;
            visitor.FilteredFileFinished += ConsoleLog;
        }

        [Test]
        public void FindMethodTest()
        {
            var expectedList = new string[]
                {
                    Path.Combine(system.GetRootFolderPath(),@"folder1"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12"),
                    Path.Combine(system.GetRootFolderPath(),@"1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"123.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"123.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"temp.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text2.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text3.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx2.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx3.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\4.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\1.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\2.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\3.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\4.bmp"),
                };

            var actualList = visitor.Find(system.GetRootFolderPath());

            Assert.That(actualList, Is.EqualTo(expectedList));
        }

        [Test]
        public void FindWithFilterMethodTest()
        {
            var expectedList = new string[]
                {
                    Path.Combine(system.GetRootFolderPath(),@"1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\4.bat"),
                };

            var actualList = visitor.FindWithFilter(system.GetRootFolderPath());

            Assert.That(actualList, Is.EqualTo(expectedList));
        }

        [Test]
        public void GetEnumeratorMethodTest()
        {
            var expectedList = new string[]
               {
                    Path.Combine(system.GetRootFolderPath(),@"folder1"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12"),
                    Path.Combine(system.GetRootFolderPath(),@"1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"123.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"123.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"temp.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text2.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text3.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx2.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx3.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\4.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\1.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\2.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\3.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\4.bmp"),
               };

            var actualList = visitor.GetEnumerator(system.GetRootFolderPath());

            Assert.That(actualList, Is.EqualTo(expectedList));
        }

        [Test]
        public void GetEnumeratorWithoutFoldersMethodTest()
        {
            var expectedList = new string[]
                {
                    Path.Combine(system.GetRootFolderPath(),@"1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"123.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"123.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"temp.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text2.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder1text3.txt"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx2.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2\folder1docx3.docx"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\1.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\2.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\3.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11\4.bat"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\1.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\2.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\3.bmp"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12\4.bmp"),
                };

            visitor.ExcludeFoldersFromSearch();
            var actualList = visitor.GetEnumerator(system.GetRootFolderPath());

            Assert.That(actualList, Is.EqualTo(expectedList));
        }

        [Test]
        public void GetEnumeratorWithoutFilesMethodTest()
        {
            var expectedList = new string[]
                {
                    Path.Combine(system.GetRootFolderPath(),@"folder1"),
                    Path.Combine(system.GetRootFolderPath(),@"folder2"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder11"),
                    Path.Combine(system.GetRootFolderPath(),@"folder1\folder12"),
                };

            visitor.ExcludeFilesFromSearch();
            var actualList = visitor.GetEnumerator(system.GetRootFolderPath());

            Assert.That(actualList, Is.EqualTo(expectedList));
        }

        private void ConsoleLog(object sender, ProgressArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}