﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDL.Models
{
    public class CurrentDate
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime currentDate { get; set; }

    }
}
