using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class TimeTable
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int ChildrenId { get; set; }
        public int ClassId { get; set; }
        public string DayInWeek { get; set; }
        public string StarTime { get; set; }
        public string EndTime { get; set; }

        public virtual Child Children { get; set; }
        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
