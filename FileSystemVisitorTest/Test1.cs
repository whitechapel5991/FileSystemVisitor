using NUnit.Framework;
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
            FileSystemVisitor.FileSystemVisitor visitor = new FileSystemVisitor.FileSystemVisitor();
            foreach(var item in visitor.GetFileTree(Directory.GetCurrentDirectory()))
            {

            }
            Assert.Pass();
        }
    }
}