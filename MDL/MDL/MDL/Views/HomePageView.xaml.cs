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
using MDL.Controls;
using Plugin.Notifications;

namespace MDL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageView : ContentPage
    {
        Items _items = new Items();
        //LeftPage is a bool to help prevent opening two new pages
        bool leftPage = false;

        public HomePageView()
        {
            InitializeComponent();
            this.Title = "My Daily List";
            //Initially populate the list from the database
            PopulateList();

            //Listens for the call to delete an item from an OnLongPress event from the custom renderer FancyLabel
            //Sends the item and passes it into the deleteitem function
            MessagingCenter.Subscribe<FancyLabel, Items>(this, "Delete", (sender, args) => {
                DeleteItem(args);
            });
            //Listens for the call to delete an item from an OnLongPress event from the custom renderer FancyLabel
            //Sends the item and passes it to the edititem function
            MessagingCenter.Subscribe<FancyLabel, Items>(this, "Edit", (sender, args) => {
                EditItem(args);
            });

        }

        async public void DeleteItem(Items item)
        {
            //Present the user with an option to cancel incase the long press was an accident
            var answer = await DisplayAlert("Delete Item", "Are you sure you want to delete this item from your list?", "Yes", "No");
            //If yes delete the item where the ID matches the sent item and rebuild the list
            if (answer)
            {
                var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
                db.Table<Items>().Delete(x => x.Id == item.Id);
                db.Close();
                PopulateList();
            }
        }

        public void PopulateList()
        {
            //Builds the listview as the Items table sorted by if it is complete and then ID
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.isComplete).OrderBy(c => c.Id).ToList();
            db.Close();           
        }

        protected override void OnAppearing()
        {
            //Whenever the page reappears we repopulate list and set leftPage to false, because we are on the page
            base.OnAppearing();
            PopulateList();
            leftPage = false;
        }

        async private void EditItem(Items item)
        {
            //Set leftPage to true so double taps won't open two pages, and then push the EditItemPage with the sent item
            if (leftPage)
            {
                return;
            }
                
            leftPage = true;

            await Navigation.PushAsync(new EditItemPage(item));
            //After the page is loaded set leftPage to false
            leftPage = false;
           
        }

        void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //If an item is tapped, deselect it, otherwise it shows orange
            if (e.Item == null)
                return;

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        void Handle_OnToggle(object sender, ToggledEventArgs e)
        {

                //This is bound to each switch in the list. When it changes it gets the Item that is attached to it
                //And updates the status
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
                        mondayAlarm = _items.mondayAlarm,
                        tuesdayAlarm = _items.tuesdayAlarm,
                        wednesdayAlarm = _items.wednesdayAlarm,
                        thursdayAlarm = _items.thursdayAlarm,
                        fridayAlarm = _items.fridayAlarm,
                        saturdayAlarm = _items.saturdayAlarm,
                        sundayAlarm = _items.sundayAlarm,
                        hasReminder = _items.hasReminder,
                        reminderTime = _items.reminderTime
                        
                    };
                        db.Update(items);
                        db.Close();
                }
        }

        async private void addBtn_Clicked(object sender, EventArgs e)
        {
           // If leftPage is true we are already trying to open a new page, so return, else push the add item page
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
