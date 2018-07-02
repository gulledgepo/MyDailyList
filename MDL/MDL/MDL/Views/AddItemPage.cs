using MDL.Interfaces;
using MDL.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MDL.Views
{
	public class AddItemPage : ContentPage
	{
         private Entry _nameEntry;
         private Entry _descriptionEntry;
         private Button _saveButton;

         //string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

         public AddItemPage ()
         {

             NavigationPage.SetHasNavigationBar(this, false);

             StackLayout stackLayout = new StackLayout();

             _nameEntry = new Entry();
             _nameEntry.Keyboard = Keyboard.Text;
             _nameEntry.Placeholder = "Item Name";
             stackLayout.Children.Add(_nameEntry);



             _descriptionEntry = new Entry();
             _descriptionEntry.Keyboard = Keyboard.Text;
             _descriptionEntry.Placeholder = "Item Description";
             stackLayout.Children.Add(_descriptionEntry);

             _saveButton = new Button();
             _saveButton.Text = "Save";
             _saveButton.Clicked += _saveButton_Clicked;
             stackLayout.Children.Add(_saveButton);

             Content = stackLayout;

         }

         private async void _saveButton_Clicked(object sender, EventArgs e)
         {
            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            db.CreateTable<Items>();

            var maxPk = db.Table<Items>().OrderByDescending(c => c.Id).FirstOrDefault();

            Items items = new Items()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                Description = _descriptionEntry.Text,
                isComplete = false
             };
             db.Insert(items);
             await DisplayAlert(null, items.Name + " added to your daily list!", "Ok.");

            await Navigation.PopAsync();

         }
     
    }
}