using MDL.Interfaces;
using MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SQLite;

namespace MDL.Views
{
	public class StartPage : TabbedPage
	{
		public StartPage ()
		{
            DateTime newDay = DateTime.Now;
            CurrentDate currentDay = new CurrentDate();
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            try
            {                            
                currentDay = db.Table<CurrentDate>().First();
                DisplayAlert("Imported Day", currentDay.currentDate.Day.ToString(), "Ok");
            }
            //If there is no table make one and make the only entry
            catch
            {
                db.CreateTable<CurrentDate>();
                CurrentDate currentDates = new CurrentDate()
                {
                    currentDate = DateTime.Now,
                    //Necessary cause of some error with 1 column
                    somethingElse = "nothing"
                };
                currentDay = currentDates;
                db.Insert(currentDates);
                DisplayAlert("New", "Creating new Table", "Ok");
            }

            if (currentDay.currentDate.Day != newDay.Day)
            {
                DisplayAlert("The days aren't the same", currentDay.currentDate.Day.ToString(), "Ok");
            }

            currentDay.currentDate = newDay;
            db.Update(currentDay);
            DisplayAlert("Saved date", currentDay.currentDate.Day.ToString(), "Ok");
            DisplayAlert("Todays date", newDay.Day.ToString(), "Ok");



            NavigationPage.SetHasNavigationBar(this, false);
            var navigationPage = new NavigationPage(new ManipulateListPage());
            navigationPage.Title = "Edit List";

            Children.Add(new HomePageView());
            Children.Add(navigationPage);




        }
	}
}