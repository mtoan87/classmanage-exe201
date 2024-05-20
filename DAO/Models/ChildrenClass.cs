﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class ChildrenClass
    {
        public ChildrenClass()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public int ClassId { get; set; }
        public int ChildrenId { get; set; }

        public virtual Child Children { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
