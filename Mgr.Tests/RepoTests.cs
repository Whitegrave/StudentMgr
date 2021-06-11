using NUnit.Framework;
using StudentMgr.Data;
using StudentMgr.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mgr.Tests
{
    [TestFixture]
    public class RepoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanReadDataFromFile()
        {
            string path = Directory.GetCurrentDirectory() + @"..\..\..\..\..\StudentMgr\Data\Database\Students_Test.txt";
            StudentRepo repo = new StudentRepo(path);

            List<Student> students = repo.List();

            Assert.IsTrue(students.Count() > 0);

            Student check = students[2];

            Assert.AreEqual("Jane", check.FirstName);
            Assert.AreEqual("Doe", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(4.0, check.GPA);
        }
    }
}