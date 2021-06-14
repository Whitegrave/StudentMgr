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
        private static string original_path = Directory.GetCurrentDirectory() + @"..\..\..\..\..\StudentMgr\Data\Database\Students_Test.txt";
        private static string live_path = Directory.GetCurrentDirectory() + @"..\..\..\..\..\StudentMgr\Data\Database\Students_Test_Live.txt";
        [SetUp]
        public void Setup()
        {
            if (File.Exists(live_path))
                File.Delete(live_path);

            File.Copy(original_path, live_path);
        }

        [Test]
        public void CanReadDataFromFile()
        {
            StudentRepo repo = new StudentRepo(live_path);
            List<Student> students = repo.List();

            Assert.IsTrue(students.Count() > 0);

            Student check = students[2];

            Assert.AreEqual("Jane", check.FirstName);
            Assert.AreEqual("Doe", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(4.0, check.GPA);
        }

        [Test]
        public void CanAddStudentToFile()
        {
            StudentRepo repo = new StudentRepo(live_path);

            Student newStudent = new Student();
            newStudent.FirstName = "Test";
            newStudent.LastName = "Tester";
            newStudent.Major = "Testing";
            newStudent.GPA = 4.0M;

            repo.Add(newStudent);
            List<Student> students = repo.List();

            Assert.IsTrue(students.Count() == 5);

            Student check = students[4];

            Assert.AreEqual("Test", check.FirstName);
            Assert.AreEqual("Tester", check.LastName);
            Assert.AreEqual("Testing", check.Major);
            Assert.AreEqual(4.0M, check.GPA);
        }
    }
}