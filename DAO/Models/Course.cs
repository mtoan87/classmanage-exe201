using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Course
    {
        public Course()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            Classes = new HashSet<Class>();
            TimeTables = new HashSet<TimeTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime OpenFormTime { get; set; }
        public DateTime CloseFormTime { get; set; }
        public double? Price { get; set; }
        public int Level { get; set; }
        public int TotalSlot { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
