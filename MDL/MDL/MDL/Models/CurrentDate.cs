using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDL.Models
{
    public class CurrentDate
    {
        [PrimaryKey]
        public DateTime currentDate { get; set; }
        //Necessary cause of an error when only 1 field is present
        public string somethingElse { get; set; }
    }
}
