using MDL.Interfaces;
using MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SQLite;


//Should be deleted
namespace MDL.Views
{
	public class StartPage : TabbedPage
	{
		public StartPage ()
		{

            NavigationPage.SetHasNavigationBar(this, false);
            var navigationPage = new NavigationPage(new HomePageView());
            navigationPage.Title = "Edit List";

            Children.Add(new HomePageView());
            Children.Add(navigationPage);

        }


    }
}