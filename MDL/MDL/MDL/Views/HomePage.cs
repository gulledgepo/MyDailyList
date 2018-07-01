using MDL.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;


//This page has been replaced by HomePageView
//This page is obsolete and should be deleted
//Hanging on to it until later







namespace MDL.Views
{
	public class HomePage : ContentPage
	{
        //private Android.Views.View _cellCore;
        //private ListView _listView;
        //private string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        //Items _items = new Items();

        public HomePage()
        {
            
                //this.Title = "My Daily List";
                //var db = new SQLiteConnection(_dbPath);
                ////var customCell = new DataTemplate(typeof(CustomCell));

                ////StackLayout stackLayout = new StackLayout();

                ////Working Listview Population
                ////_listView = new ListView();
                ////_listView.ItemTemplate = customCell;
                ////_listView.ItemsSource = db.Table<Items>().OrderBy(x => x.Name).ToList();
                ////stackLayout.Children.Add(_listView);
                //var dbItemList = db.Table<Items>().OrderBy(x => x.Name).ToList();
                //var itemList = new ObservableCollection<Items>();

                ////foreach (var item in dbItemList)
                ////{
                ////    itemList.Add(item);
                ////};
                //dbItemList.ForEach(item => itemList.Add(item));

                //SwitchCell switchCell = new SwitchCell();
                //_listView = new ListView();
                //_listView.ItemsSource = itemList;
                //_listView.ItemTemplate = new DataTemplate(typeof(CustomCell));

               
                //switchCell.OnChanged += SwitchCell_BindingContextChanged;
                //_listView.ItemTemplate.SetBinding(SwitchCell.TextProperty, "Name");
                //_listView.ItemTemplate.SetBinding(SwitchCell.OnProperty, "isComplete");
                //_listView.ItemSelected += _listView_ItemSelected;
                //_listView.PropertyChanged += _listView_PropertyChanged;
                
                ////_listView.ItemTemplate = new DataTemplate(() =>
                ////{
                ////    Label nameLabel = new Label();
                ////    nameLabel.SetBinding(Label.TextProperty, "Name");
                ////    Label descLabel = new Label();
                ////    descLabel.SetBinding(Label.TextProperty, new binding("Description");
                ////}
                //////Experiments
                ////ObservableCollection<> itemList = new ObservableCollection<>();
                ////var maxPk = db.Table<Items>().OrderByDescending(c => c.Id).FirstOrDefault();
                ////_listView.ItemsSource = itemList;
                ////for (int i = 0; i < maxPk.Id + 1; i++)
                ////{
                ////    itemList.Add(db.Get<Items>(i));
                ////}
                ////stackLayout.Children.Add(_listView);


                //Content = _listView;

            

        }
    }

}