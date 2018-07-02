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
	public class EditListPage : ContentPage
	{

        private ListView _listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _descriptionEntry;
        private Button _button;

        Items _items = new Items();

        //string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");



        public EditListPage ()
		{
            this.Title = "Edit List";

            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Item Name";
            stackLayout.Children.Add(_nameEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Item Description";
            stackLayout.Children.Add(_descriptionEntry);

            _button = new Button();
            _button.Text = "Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            //var db = new SQLiteConnection(_dbPath);
            var db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            Items items = new Items()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Description = _descriptionEntry.Text
            };
            db.Update(items);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _items = (Items)e.SelectedItem;
            _idEntry.Text = _items.Id.ToString();
            _nameEntry.Text = _items.Name;
            _descriptionEntry.Text = _items.Description;
        }
    }
}