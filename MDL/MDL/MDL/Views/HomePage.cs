using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MDL.Views
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            this.Title = "Select options";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Item";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "View List";
            button.Clicked += Button_View_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit Items";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Items";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }

        private async void Button_View_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewListPage());
            
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditListPage());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteItemsPage());
        }
    }
}