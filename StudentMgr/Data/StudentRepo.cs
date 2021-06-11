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
            throw new NotImplementedException();
        }

        public void Edit(Student toEdit, int index)
        {
            throw new NotImplementedException();
        }

        public void Delete (int toDelete)
        {
            throw new NotImplementedException();
        }
    }
}
