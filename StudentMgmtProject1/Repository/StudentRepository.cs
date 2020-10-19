using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentMgmtProject1.Models;

namespace StudentMgmtProject1.Repository
{
    public class StudentRepository : IStudent
    {
        private Student1Context context;
        public StudentRepository(Student1Context context)
        {
            this.context = context;

        }

        public IEnumerable<StudentRecords> GetAll()
        {
            var list = context.StudentRecords.ToList();
            return list;
        }

        public StudentRecords GetById(int id)
        {
            StudentRecords record = context.StudentRecords.Find(id);
            return record;
        }

        public int UpdateStudent(StudentRecords record)
        {
            context.Entry(record).State = EntityState.Modified;
            int response = context.SaveChanges();
            return response;
        }

        public int AddStudent(StudentRecords record)
        {
            context.StudentRecords.Add(record);
            int response = context.SaveChanges();
            return response;
        }

        public int DeleteStudent(StudentRecords record)
        {
            context.StudentRecords.Remove(record);
            var response = context.SaveChanges();
            return response;
        }
    }
}
