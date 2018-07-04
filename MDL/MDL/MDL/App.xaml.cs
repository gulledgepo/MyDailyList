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
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MDL
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            checkDate();
            MainPage = new NavigationPage(new StartPage());
		}

		protected override void OnStart ()
		{
            checkDate();
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
		}

        private void checkDate()
        {
            DateTime newDay = DateTime.Now;
            CurrentDate currentDay = new CurrentDate();
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            //db.DropTable<CurrentDate>();
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
        }
    }
}
