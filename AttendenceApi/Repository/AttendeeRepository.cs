using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendenceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendenceApi.Repository
{
    public class AttendeeRepository : IAttendee
    {

         Student1Context context;
        public AttendeeRepository(Student1Context context)
        {
            this.context = context;

        }

        public AttendeeRepository()
        {

        }

        public int AddAttendence(AttendeeRecords record)
        {
            context.AttendeeRecords.Add(record);
            int response = context.SaveChanges();
            return response;
        }

        public int DeleteAttendence(AttendeeRecords record)
        {
            context.AttendeeRecords.Remove(record);
            var response = context.SaveChanges();
            return response;
        }

        public IEnumerable<AttendeeRecords> GetAll()
        {
            if (context != null)
            {
                var list = context.AttendeeRecords.ToList();
                return list;
            }
            return null;

            
        } 

        public AttendeeRecords GetById(int id)
        {
            AttendeeRecords record = context.AttendeeRecords.Find(id);
            return record;
        }

        public int UpdateAttendence(AttendeeRecords record)
        {
            context.Entry(record).State = EntityState.Modified;
            int response = context.SaveChanges();
            return response;
        }
    }
}
