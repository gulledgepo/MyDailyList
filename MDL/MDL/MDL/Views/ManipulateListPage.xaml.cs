using MDL.Models;
using SQLite;
using System;
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
    public partial class ManipulateListPage : ContentPage
    {

        private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        Items _items = new Items();


        public ManipulateListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //var db = new SQLiteConnection(_dbPath);
            //var dbItemList = db.Table<Items>().OrderBy(x => x.Name).ToList();
            //var itemList = new ObservableCollection<Items>();
            //dbItemList.ForEach(item => itemList.Add(item));
            //_listView.ItemsSource = itemList;
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

            ManipulateListPage viewModel = new ManipulateListPage();
            PopulateList();

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void deleteBtn_Clicked(object sender, EventArgs e)
        {

        }

        async private void addBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
