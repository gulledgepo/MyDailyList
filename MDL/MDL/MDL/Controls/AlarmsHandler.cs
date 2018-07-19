using MDL.Interfaces;
using MDL.Models;
using System;
//using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using System.Linq;
using Plugin.Notifications;

namespace MDL.Controls
{
    public class AlarmsHandler
    {
        public AlarmsHandler()
        {
        }

        public void HandleAlarm()
        {
            //HandleAlarm()
            //Cancels all pending alarms so that they can be rebuilt.
            //Creates a list of all items in the Items table. Gets the current day in the DayOfWeek
            //7 different Ifs for the day checking if the stored corresponding boolean is true
            //If it is true, it gets the current time and finds the difference from the stored time for the reminder
            //If that isn't negative it means the alarm needs to be set, creates the notification with the name and description of the item
            CrossNotifications.Current.CancelAll();
            DateTime currentDayOfWeek = DateTime.Now;
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            var dbItemList = db.Table<Items>().OrderBy(x => x.Id).ToList();
            //CrossNotifications.Current.Send(new Notification
            //{
            //    Title = "Samples",
            //    Message = "Starting Sample Schedule Notifications"
            //});

            //An item has to not be complete to get a reminder, if it is complete they already did it today regardless of whether a
            //reminder is required. additionally, the hasReminder has to be true, for convenience the reminder day and time is stored even when 
            //hasreminder is off, so this must be checked
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Monday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.mondayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,                                            
                                            Sound = "default",
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                            }
                                }
                            }
                        }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Tuesday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.tuesdayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Wednesday)
                    {
                    foreach (var item in dbItemList)
                    {
                        if (item.isComplete == false && item.hasReminder == true)
                        {
                            if (item.wednesdayAlarm == true)
                            {
                                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                TimeSpan difference = item.reminderTime - currentTime;
                                string differenceAsString = difference.ToString().ToString();
                                if (!differenceAsString.Contains("-"))
                                {
                                    var id = CrossNotifications.Current.Send(new Notification
                                    {
                                        Title = item.Name,
                                        Message = item.Description,
                                        Vibrate = true,
                                        When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                    });
                                }
                            }
                        }
                    }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Thursday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.thursdayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Friday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.fridayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Saturday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.saturdayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                                    }
                                }
                            }
                        }
                    }
                    if (currentDayOfWeek.DayOfWeek == DayOfWeek.Sunday)
                    {
                        foreach (var item in dbItemList)
                        {
                            if (item.isComplete == false && item.hasReminder == true)
                            {
                                if (item.sundayAlarm == true)
                                {
                                    TimeSpan currentTime = DateTime.Now.TimeOfDay;
                                    TimeSpan difference = item.reminderTime - currentTime;
                                    string differenceAsString = difference.ToString().ToString();
                                    if (!differenceAsString.Contains("-"))
                                    {
                                        var id = CrossNotifications.Current.Send(new Notification
                                        {
                                            Title = item.Name,
                                            Message = item.Description,
                                            Vibrate = true,
                                            When = TimeSpan.FromSeconds(difference.TotalSeconds)
                                        });
                                    }
                                }
                            }
                        }
                    }
                         
            db.Close();
        }
    }
}
