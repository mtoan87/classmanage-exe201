﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Class
    {
        public Class()
        {
            CartItems = new HashSet<CartItem>();
            ChildrenClasses = new HashSet<ChildrenClass>();
            ClassTimes = new HashSet<ClassTime>();
            TimeTables = new HashSet<TimeTable>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalAmount { get; set; }
        public int Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<ChildrenClass> ChildrenClasses { get; set; }
        public virtual ICollection<ClassTime> ClassTimes { get; set; }
        public virtual ICollection<TimeTable> TimeTables { get; set; }
    }
}
