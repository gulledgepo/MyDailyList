using MDL.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;




//This page is mostly obsolete
//Replaced by HomePageView
//should be deleted soon





namespace MDL.Views
{
	public class ViewListPage : ContentPage
	{
        private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public ViewListPage ()
		{
            this.Title = "My Daily List";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
		}
	}
}