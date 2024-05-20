﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            Classes = new HashSet<Class>();
            TimeTables = new HashSet<TimeTable>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
