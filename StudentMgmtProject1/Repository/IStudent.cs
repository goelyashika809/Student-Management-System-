using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentMgmtProject1.Models;

namespace StudentMgmtProject1.Repository
{
   public interface IStudent
    {
        public IEnumerable<StudentRecords> GetAll();

        public StudentRecords GetById(int id);

        public int AddStudent(StudentRecords record);

        public int UpdateStudent(StudentRecords record);

        public int DeleteStudent(StudentRecords record);
    }
}
