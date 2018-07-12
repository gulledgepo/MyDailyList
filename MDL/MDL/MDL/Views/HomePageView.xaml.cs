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
using MDL;

namespace MDL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {


        Items _items = new Items();
        bool leftPage = false;

        public HomePageView()
        {
            InitializeComponent();
            this.Title = "My Daily List";       

            PopulateList();




        }

        private void HandleSingleTap()
        {

        }

        public void PopulateList()
        {
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();

            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.isComplete).OrderBy(c => c.Id).ToList();
            db.Close();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateList();
            leftPage = false;

        }

        async private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Items selectedItem = ((ListView)sender).SelectedItem as Items;
            ((ListView)sender).SelectedItem = null;
            if (leftPage)
            {
                return;
            }
                
            leftPage = true;

            await Navigation.PushAsync(new EditItemPage(selectedItem));

            leftPage = false;
            

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
                    var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
                    Items items = new Items()
                    {
                        Id = Convert.ToInt32(_items.Id.ToString()),
                        Name = _items.Name,
                        Description = _items.Description,
                        isComplete = getComplete,
                        mondayAlarm = _items.mondayAlarm
                    };
                        db.Update(items);
                        db.Close();
                }
        }

        async private void addBtn_Clicked(object sender, EventArgs e)
        {
            if (leftPage)
            {
                return;
            }

            leftPage = true;
            await Navigation.PushAsync(new AddItemPage());

            leftPage = false;
        }
    }
}
