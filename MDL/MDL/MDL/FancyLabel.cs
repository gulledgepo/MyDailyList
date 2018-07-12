using MDL.Interfaces;
using MDL.Models;
using MDL.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MDL
{

        public class FancyLabel : Label
        {

        public FancyLabel()
            {
            }

        public EventHandler LongPressActivated;
        public EventHandler SingleTapActivated;

        public void HandleLongPress(object sender, EventArgs e)
        {
            //Handle LongPressActivated Event
            EventHandler eventHandler = this.LongPressActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            Console.WriteLine("2 2 2 ");
        }

        async public void HandleSingleTap(object sender, EventArgs e)
        {
            EventHandler eventHandler = this.SingleTapActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            Console.WriteLine("2 3333332 2 ");
            Items selectedItem = this.BindingContext as Items;
            //if (leftPage)
            //{
            //    return;
            //}


            await Navigation.PushAsync(new EditItemPage(selectedItem));

        }

    }
    
}
