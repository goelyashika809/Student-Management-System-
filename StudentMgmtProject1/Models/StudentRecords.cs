using System;
using System.Collections.Generic;

namespace StudentMgmtProject1.Models
{
    public partial class StudentRecords
    {
        public StudentRecords()
        {
            AttendeeRecords = new HashSet<AttendeeRecords>();
        }

        public int Rollno { get; set; }
        public string Name { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Percentage { get; set; }

        public virtual ICollection<AttendeeRecords> AttendeeRecords { get; set; }
    }
}
