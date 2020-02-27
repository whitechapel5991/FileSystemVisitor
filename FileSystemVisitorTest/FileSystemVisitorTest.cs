using FileSystemVisitor;
using FileSystemVisitorTest.FakeFileSystem;
using NUnit.Framework;
using System;
using System.IO;
using Visitor = FileSystemVisitor.FileSystemVisitor;

namespace FileSystemVisitorTest
{
    public class Tests
    {
        private Visitor visitor;

        [SetUp]
        public void Setup()
        {
            FileSystem system = new FileSystem();
            system.InitFakeFileSystem();

            visitor = new Visitor(() => "Reflection*");
            visitor.Start += ConsoleLog;
            visitor.Finish += ConsoleLog;
            visitor.DirectoryFinished += ConsoleLog;
            visitor.FileFinished += ConsoleLog;
            visitor.FilteredDirectoryFinished += ConsoleLog;
            visitor.FilteredFileFinished += ConsoleLog;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        private void ConsoleLog(object sender, ProgressArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}