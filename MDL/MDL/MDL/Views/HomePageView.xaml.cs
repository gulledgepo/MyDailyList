using MDL.Interfaces;
using MDL.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {

        //private SQLiteConnection database;
        //private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        Items _items = new Items();

        public HomePageView()
        {
            InitializeComponent();

            this.Title = "My Daily List";

            DateTime newDate = DateTime.Now;
            



            PopulateList();

        }

        private void PopulateList()
        {
            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();

            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Id).ToList();
            db.Close();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            HomePageView viewModel = new HomePageView();
            PopulateList();

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _listView.SelectedItem = null;
        }

        //private void Handle_OnChanged(object sender, ToggledEventArgs args)
        //{

        //}


        void Handle_OnToggle(object sender, ToggledEventArgs e)
        {

                var getComplete = e.Value;
                var selectedItem = ((Switch)sender).BindingContext as Items;
                if (selectedItem != null)
                {
                    _items = selectedItem;
                    //var db = new SQLiteConnection(_dbPath);
                    var db = DependencyService.Get<IDatabaseConnection>().DbConnection();

                    Items items = new Items()
                    {
                        Id = Convert.ToInt32(_items.Id.ToString()),
                        Name = _items.Name,
                        Description = _items.Description,
                        isComplete = getComplete

                    };
                    db.Update(items);
                    db.Close();
                }
        }
    }
}
