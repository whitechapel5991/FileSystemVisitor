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
            Folder root = new Folder(@"d:\TKMI\");
            //root.BuildFileSystemTree();
            var list = root.Children;

            //var list2 = root.GetAllFoldersAndFiles();

            //FileSystemVisitor.FileSystemVisitor visitor = new FileSystemVisitor.FileSystemVisitor();
            Assert.Pass();
        }
    }
}