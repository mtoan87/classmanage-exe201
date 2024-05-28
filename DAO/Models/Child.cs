using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Child
    {
        public Child()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            ChildrenClasses = new HashSet<ChildrenClass>();
            TimeTables = new HashSet<TimeTable>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string ImgUrl { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<ChildrenClass> ChildrenClasses { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
