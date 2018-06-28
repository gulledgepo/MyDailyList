﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDL.Models
{
    public class Items
    {
            [PrimaryKey]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

        public override string ToString()
        {
            return this.Name + ": " + this.Description + ".";
        }

    }

}
