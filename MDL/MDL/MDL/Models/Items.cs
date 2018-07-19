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
        //If the item has been accomplished
        public bool isComplete { get; set; }
        //If the item has a reminder
        public bool hasReminder { get; set; }
        //Alarms for each of the 7 days
        public bool mondayAlarm { get; set; }
        public bool tuesdayAlarm { get; set; }
        public bool wednesdayAlarm { get; set; }
        public bool thursdayAlarm { get; set; }
        public bool fridayAlarm { get; set; }
        public bool saturdayAlarm { get; set; }
        public bool sundayAlarm { get; set; }
        //The reminder time for the notification
        public TimeSpan reminderTime { get; set; }

        public override string ToString()
        {
            return this.Name + ": " + this.Description + ".";
        }

    }

}

