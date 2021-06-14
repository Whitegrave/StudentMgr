using StudentMgr.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMgr.Data
{
    public class StudentRepo
    {
        private string filePath;
        public StudentRepo(string path)
        {
            this.filePath = path;
        }
        public List<Student> List()
        {
            List<Student> students = new List<Student>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine(); // Skips first line, discards
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Student newStudent = new Student();

                    string[] columns = line.Split(",");
                    newStudent.FirstName = columns[0];
                    newStudent.LastName = columns[1];
                    newStudent.Major = columns[2];
                    newStudent.GPA = decimal.Parse(columns[3]);

                    students.Add(newStudent);
                }
            }

            return students;
        }

        public void Add(Student toAdd)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(CreateStudentCSV(toAdd));
            }
        }

        public void Edit(Student toEdit, int index)
        {
            var students = List();
            students[index] = toEdit;
            CreateStudentFile(students);
        }

        public void Delete (int toDelete)
        {
            var students = List();
            students.RemoveAt(toDelete);
            CreateStudentFile(students);
        }

        private string CreateStudentCSV(Student student)
        {
            return $"{student.FirstName},{student.LastName},{student.Major},{student.GPA.ToString()}";
        }
        private void CreateStudentFile(List<Student> students)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using(StreamWriter sr = new StreamWriter(filePath))
            {
                sr.WriteLine("FirstName,LastName,Major,GPA");
                foreach (var item in students)
                {
                    sr.WriteLine(CreateStudentCSV(item));
                }
            }
        }
    }
}
