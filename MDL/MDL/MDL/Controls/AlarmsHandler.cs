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
            CrossNotifications.Current.CancelAll();
            DateTime currentDayOfWeek = DateTime.Now;
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            var dbItemList = db.Table<Items>().OrderBy(x => x.Id).ToList();
            //CrossNotifications.Current.Send(new Notification
            //{
            //    Title = "Samples",
            //    Message = "Starting Sample Schedule Notifications"
            //});
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Monday)
            {
                foreach (var item in dbItemList)
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
                                When = TimeSpan.FromSeconds(difference.TotalSeconds)
                            });
                        }
                    }
                }
            }
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Tuesday)
            {
                foreach (var item in dbItemList)
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
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Wednesday)
            {
                foreach (var item in dbItemList)
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
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Thursday)
            {
                foreach (var item in dbItemList)
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
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Friday)
            {
                foreach (var item in dbItemList)
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
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Saturday)
            {
                foreach (var item in dbItemList)
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
            if (currentDayOfWeek.DayOfWeek == DayOfWeek.Sunday)
            {
                foreach (var item in dbItemList)
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
            db.Close();
        }
    }
}
