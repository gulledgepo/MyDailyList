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
        private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        Items _items = new Items();

        public HomePageView()
        {
            InitializeComponent();

            this.Title = "My Daily List";

            PopulateList();

        }

        private void PopulateList()
        {
            var db = new SQLiteConnection(_dbPath);

            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Name).ToList();
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

        private void Handle_OnChanged(object sender, ToggledEventArgs args)
        {

        }


        void Handle_OnToggle(object sender, ToggledEventArgs e)
        {
            var getComplete = e.Value;
            var selectedItem = ((Switch)sender).BindingContext as Items;

            _items = selectedItem;
            var db = new SQLiteConnection(_dbPath);
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
