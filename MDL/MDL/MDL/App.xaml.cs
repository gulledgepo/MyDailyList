using MDL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using MDL.Models;
using MDL.Interfaces;
using Plugin.Notifications;
using MDL.Controls;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MDL
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            CheckItems();
            CheckDate();
            //Start our view of HomePageView
            MainPage = new NavigationPage(new HomePageView());
		}

		protected override void OnStart ()
		{
            //When the app starts, check to see if the date has changed and if so reset the items in list
            CheckDate();
            //Alarms are redone the app is start
            var alarmsHandler = new AlarmsHandler();
            alarmsHandler.HandleAlarm();
            // Handle when your app starts
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
            //When the app resumes, check to see if the date has changed and if so reset the items in list
            CheckDate();
            //Alarms are redone the app is resumed
            var alarmsHandler = new AlarmsHandler();
            alarmsHandler.HandleAlarm();
		}

        private void CheckItems()
        {
            //CheckItems()
            //Checks to see if it can find the first item in the Items table. If it can, then it means
            //that the table exist. If it can't, then the table doesn't exist and we create it with all the necessary fields.
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            //This is used for testing to easily reset table
            //db.DropTable<Items>();
            Items testItem = new Items();
            try
            {
                testItem = db.Table<Items>().First();
            }
            catch
            {
                db.CreateTable<Items>();

                var maxPk = db.Table<Items>().OrderByDescending(c => c.Id).FirstOrDefault();
                TimeSpan addTime = new TimeSpan(22, 30, 0);
                Items items = new Items()
                {
                    Id = (maxPk == null ? 1 : maxPk.Id + 1),
                    Name = "Tap to edit item.",
                    Description = "Hold then release to delete. \n\nMark items complete on the right.\n\nCompleted items will be reset each new day. \n\nItems can be given timed reminders upon creation or when being edited.",
                    isComplete = false,
                    mondayAlarm = true,
                    tuesdayAlarm = false,
                    wednesdayAlarm = false,
                    thursdayAlarm = false,
                    fridayAlarm = false,
                    saturdayAlarm = false,
                    sundayAlarm = false,
                    reminderTime = addTime,
                    hasReminder = false
                    
                };
                db.Insert(items);
            }
        }

        private void CheckDate()
        {
            //checkDate()
            //Checks to see if the date has changed. A table for CurrentDate holds the DateTime from the last time the app was opened
            //It is then compared to the current date of the app being opened. If it has changed, it resets all isComplete in the 
            //Items table to false. Also sets the currentDate to the newDate

            DateTime newDay = DateTime.Now;
            CurrentDate currentDay = new CurrentDate();
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            //db.DropTable<CurrentDate>();
            //db.DropTable<Items>();
            try
            {
                currentDay = db.Table<CurrentDate>().First();
            }
            //If there is no table make one and make the only entry
            catch
            {
                db.CreateTable<CurrentDate>();
                currentDay = new CurrentDate()
                {
                    currentDate = DateTime.Now,
                    Id = 1
                };
                db.Insert(currentDay);
            }
            //If the day or month has changed reset the list
            if (currentDay.currentDate.Day != newDay.Day || (currentDay.currentDate.Month != newDay.Month))
            {
                db.Execute("UPDATE Items SET isComplete='false'");
            }
            currentDay.currentDate = newDay;
            db.Update(currentDay);
            db.Close();
        }
        
    }
}
