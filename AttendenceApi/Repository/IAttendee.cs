using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendenceApi.Models;

namespace AttendenceApi.Repository
{
    public interface IAttendee
    {
        public IEnumerable<AttendeeRecords> GetAll();

        public AttendeeRecords GetById(int id);

        public int AddAttendence(AttendeeRecords record);

        public int UpdateAttendence(AttendeeRecords record);

        public int DeleteAttendence(AttendeeRecords record);
    }
}
