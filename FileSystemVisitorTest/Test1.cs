using FileSystemVisitor.Entities;
using NUnit.Framework;
using System;
using System.IO;

namespace FileSystemVisitorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Folder root = new Folder(@"d:\проги_дес\музыка\");
            root.BuildFileSystemTree();
            var list = root.children;

            var list2 = root.GetAllFoldersAndFiles();

            FileSystemVisitor.FileSystemVisitor visitor = new FileSystemVisitor.FileSystemVisitor();
            foreach(var item in visitor.GetFileTree(Directory.GetCurrentDirectory()))
            {

            }
            Assert.Pass();
        }
    }
}