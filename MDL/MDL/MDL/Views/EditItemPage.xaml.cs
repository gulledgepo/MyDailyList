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
	public partial class EditItemPage : ContentPage
	{

        private bool getComplete;
        Items _items = new Items();
        private bool getMonday;
        private bool getTuesday;
        private bool getWednesday;
        private bool getThursday;
        private bool getFriday;
        private bool getSaturday;
        private bool getSunday;
        private bool getReminder;
        private TimeSpan getTime;

        public EditItemPage (Items sentItem)
		{          
            this.Title = "Edit Item";
            InitializeComponent();

            //Loads all the sentItem into the corresponding xaml forms
            entryID.Text = sentItem.Id.ToString();
            entryName.Text = sentItem.Name;
            entryDescription.Text = sentItem.Description;
            getComplete = sentItem.isComplete;
            getMonday = sentItem.mondayAlarm;
            getTuesday = sentItem.tuesdayAlarm;
            getWednesday = sentItem.wednesdayAlarm;
            getThursday = sentItem.thursdayAlarm;
            getFriday = sentItem.fridayAlarm;
            getSaturday = sentItem.saturdayAlarm;
            getSunday = sentItem.sundayAlarm;
            getTime = sentItem.reminderTime;
            selectedTime.Time = sentItem.reminderTime;
            getReminder = sentItem.hasReminder;
            switchReminder.IsToggled = getReminder;
            //Call handle buttons to change the color of them based on the loaded values of the booleans for each day to simulate them being enabled
            HandleButtons();
        }

        async private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            Items items = new Items()
            {
                Id = Convert.ToInt32(entryID.Text),
                Name = entryName.Text,
                Description = entryDescription.Text,
                isComplete = getComplete,
                mondayAlarm = getMonday,
                tuesdayAlarm = getTuesday,
                wednesdayAlarm = getWednesday,
                thursdayAlarm = getThursday,
                fridayAlarm = getFriday,
                saturdayAlarm = getSaturday,
                sundayAlarm = getSunday,
                reminderTime = selectedTime.Time,
                hasReminder = getReminder
            };
            db.Update(items);
            db.Close();
            var alarmsHandler = new AlarmsHandler();
            alarmsHandler.HandleAlarm();
            await Navigation.PopAsync();
        }

        //Long function to change the color of the buttons to simulate being enabled and disabled
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
            //Set the getTime variable to the timepickers current time
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                getTime = selectedTime.Time;
            }
        }
        //If there is no reminder required the controls for the reminder are hidden, if the switch turns on they are shown
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

        async private void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}