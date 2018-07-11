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
            checkItems();
            checkDate();
            MainPage = new NavigationPage(new HomePageView());
		}

		protected override void OnStart ()
		{
            checkDate();
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
            checkDate();
            var alarmsHandler = new AlarmsHandler();
            alarmsHandler.HandleAlarm();
		}

        private void checkItems()
        {
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
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
                    Description = "Swipe to delete.",
                    isComplete = false,
                    mondayAlarm = true,
                    tuesdayAlarm = false,
                    wednesdayAlarm = false,
                    thursdayAlarm = false,
                    fridayAlarm = false,
                    saturdayAlarm = false,
                    sundayAlarm = false,
                    reminderTime = addTime,
                    hasReminder = true
                    
                };
                db.Insert(items);
            }
        }

        private void checkDate()
        {
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
