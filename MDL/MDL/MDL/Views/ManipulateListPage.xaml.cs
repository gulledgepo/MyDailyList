using MDL.Interfaces;
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

        //private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

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

            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Id).ToList();
            db.Close();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ManipulateListPage viewModel = new ManipulateListPage();
            PopulateList();

        }

         void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if (e.Item == null)
            //    return;

            ////Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        async private void editBtn_Clicked(object sender, EventArgs e)
        {
            Items selectedItem = ((Button)sender).BindingContext as Items;
            await Navigation.PushAsync(new EditListPage(selectedItem));
        }

        async private void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Delete Item", "Are you sure you want to delete this item from your list?", "Yes", "No");
            if (answer)
            {
                Items selectedItem = ((Button)sender).BindingContext as Items;
                var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
                db.Table<Items>().Delete(x => x.Id == selectedItem.Id);
                db.Close();
                PopulateList();
            }


        }

        async private void addBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }
    }
}
