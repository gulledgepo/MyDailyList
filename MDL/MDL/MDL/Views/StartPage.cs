using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MDL.Views
{
	public class StartPage : TabbedPage
	{
		public StartPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            var navigationPage = new NavigationPage(new ManipulateListPage());
            navigationPage.Title = "Edit List";

            Children.Add(new HomePageView());
            Children.Add(navigationPage);
        }
	}
}