using MDL.Controls;
using MDL.Interfaces;
using MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MDL.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{

        //Items _items = new Items();
        private bool getMonday = false;
        private bool getTuesday = false;
        private bool getWednesday = false;
        private bool getThursday = false;
        private bool getFriday = false;
        private bool getSaturday = false;
        private bool getSunday = false;
        private bool getReminder = false;
        private TimeSpan getTime;

        public AddItemPage ()
		{
            this.Title = "Add Item";
            InitializeComponent ();

            entryName.Placeholder = "Item Name";
            entryDescription.Placeholder = "Item Description";
            getTime = selectedTime.Time;

        }

        async private void btnAdd_Clicked(object sender, EventArgs e)
        {
            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            db.CreateTable<Items>();

            var maxPk = db.Table<Items>().OrderByDescending(c => c.Id).FirstOrDefault();
            TimeSpan addTime = new TimeSpan(10, 30, 0);
            Items items = new Items()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = entryName.Text,
                Description = entryDescription.Text,
                isComplete = false,
                mondayAlarm = true,
                tuesdayAlarm = false,
                wednesdayAlarm = false,
                thursdayAlarm = false,
                fridayAlarm = false,
                saturdayAlarm = false,
                sundayAlarm = false,
                reminderTime = getTime,
                hasReminder = false
            };
            db.Insert(items);
            await DisplayAlert(null, items.Name + " added to your daily list!", "Ok.");

            await Navigation.PopAsync();
            var alarmsHandler = new AlarmsHandler();
            alarmsHandler.HandleAlarm();

        }

        private void btnMonday_Clicked(object sender, EventArgs e)
        {
            if (getMonday)
            {
                getMonday = false;
                btnMonday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getMonday = true;
                btnMonday.BackgroundColor = Color.Gray;
            }

        }

        private void btnTuesday_Clicked(object sender, EventArgs e)
        {
            if (getTuesday)
            {
                getTuesday = false;
                btnTuesday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getTuesday = true;
                btnTuesday.BackgroundColor = Color.Gray;
            }
        }

        private void btnWednesday_Clicked(object sender, EventArgs e)
        {
            if (getWednesday)
            {
                getWednesday = false;
                btnWednesday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getWednesday = true;
                btnWednesday.BackgroundColor = Color.Gray;
            }
        }

        private void btnThursday_Clicked(object sender, EventArgs e)
        {
            if (getThursday)
            {
                getThursday = false;
                btnThursday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getThursday = true;
                btnThursday.BackgroundColor = Color.Gray;
            }
        }

        private void btnFri_Clicked(object sender, EventArgs e)
        {
            if (getFriday)
            {
                getFriday = false;
                btnFriday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getFriday = true;
                btnFriday.BackgroundColor = Color.Gray;
            }
        }

        private void btnSaturday_Clicked(object sender, EventArgs e)
        {
            if (getSaturday)
            {
                getSaturday = false;
                btnSaturday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getSaturday = true;
                btnSaturday.BackgroundColor = Color.Gray;
            }
        }

        private void btnSunday_Clicked(object sender, EventArgs e)
        {
            if (getSunday)
            {
                getSunday = false;
                btnSunday.BackgroundColor = Color.LightGray;
            }
            else
            {
                getSunday = true;
                btnSunday.BackgroundColor = Color.Gray;
            }
        }

        private void selectedTime_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                getTime = selectedTime.Time;
            }
        }

        private void switchReminder_Toggled(object sender, ToggledEventArgs e)
        {
            getReminder = e.Value;

            if (getReminder == false)
            {
                btnMonday.IsVisible = false;
                btnTuesday.IsVisible = false;
                btnWednesday.IsVisible = false;
                btnThursday.IsVisible = false;
                btnFriday.IsVisible = false;
                btnSaturday.IsVisible = false;
                btnSunday.IsVisible = false;
            }
            else
            {
                btnMonday.IsVisible = true;
                btnTuesday.IsVisible = true;
                btnWednesday.IsVisible = true;
                btnThursday.IsVisible = true;
                btnFriday.IsVisible = true;
                btnSaturday.IsVisible = true;
                btnSunday.IsVisible = true;
            }
        }

        private void HandleButtons()
        {
            if (!getMonday)
            {
                btnMonday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnMonday.BackgroundColor = Color.Gray;
            }
            if (!getTuesday)
            {
                btnTuesday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnTuesday.BackgroundColor = Color.Gray;
            }
            if (!getWednesday)
            {
                btnWednesday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnWednesday.BackgroundColor = Color.Gray;
            }
            if (!getThursday)
            {
                btnThursday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnThursday.BackgroundColor = Color.Gray;
            }
            if (!getFriday)
            {
                btnFriday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnFriday.BackgroundColor = Color.Gray;
            }
            if (!getSaturday)
            {
                btnSaturday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnSaturday.BackgroundColor = Color.Gray;
            }
            if (!getSunday)
            {
                btnSunday.BackgroundColor = Color.LightGray;
            }
            else
            {
                btnSunday.BackgroundColor = Color.Gray;
            }
        }
    }
}