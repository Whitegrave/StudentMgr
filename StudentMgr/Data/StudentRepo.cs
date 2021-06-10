using StudentMgr.Models;
using System;
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
            throw new NotImplementedException();
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
