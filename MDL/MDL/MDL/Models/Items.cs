using SQLite;
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
        public bool isComplete { get; set; }
        public bool hasReminder { get; set; }
        public bool mondayAlarm { get; set; }
        public bool tuesdayAlarm { get; set; }
        public bool wednesdayAlarm { get; set; }
        public bool thursdayAlarm { get; set; }
        public bool fridayAlarm { get; set; }
        public bool saturdayAlarm { get; set; }
        public bool sundayAlarm { get; set; }
        public TimeSpan reminderTime { get; set; }

        public override string ToString()
        {
            return this.Name + ": " + this.Description + ".";
        }

    }

}

