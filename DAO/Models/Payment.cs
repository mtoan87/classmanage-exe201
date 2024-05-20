﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAO.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PaidTime { get; set; }
        public int Method { get; set; }
        public int Status { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
