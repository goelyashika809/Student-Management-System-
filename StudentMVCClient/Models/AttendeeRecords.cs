using System;
using System.Collections.Generic;

namespace StudentMVCClient.Models
{
    public partial class AttendeeRecords
    {
        public int Attnid { get; set; }
        public int Rollno { get; set; }
        public string Subject { get; set; }
        public string Attendence { get; set; }

        public virtual StudentRecords RollnoNavigation { get; set; }
    }
}
