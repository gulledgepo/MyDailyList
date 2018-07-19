using MDL.Controls;
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

        //public event EventHandler StatusUpdated;
        public EventHandler LongPressActivated;
        public EventHandler SingleTapActivated;
        public EventHandler SingleTapUpActivated;
        public EventHandler OnFlingActivated;
        public EventHandler DoubleTapActivated;

        public void HandleLongPress(object sender, EventArgs e)
        {
            //Handle LongPressActivated Event
            //Handles the event from the OnLongPress from the android renderer
            EventHandler eventHandler = this.LongPressActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            //Sets selectedItem to the triggering item and sends the message out to be received by homepageview
            Items selectedItem = this.BindingContext as Items;
            MessagingCenter.Send<FancyLabel, Items>(this, "Delete", selectedItem);
        }

        public void HandleSingleTap(object sender, EventArgs e)
        {
            //Handles the event from the SingleTap from the android renderer
            EventHandler eventHandler = this.SingleTapActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            //Sets selectedItem to the triggering item and sends the message out to be received by homepageview
            Items selectedItem = this.BindingContext as Items;
            MessagingCenter.Send<FancyLabel, Items>(this, "Edit", selectedItem);

        }

        public void HandleSingleTapUp(object sender, EventArgs e)
        {
            //Handles the event from the SingleTap from the android renderer
            EventHandler eventHandler = this.SingleTapUpActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            //Sets selectedItem to the triggering item and sends the message out to be received by homepageview
            Items selectedItem = this.BindingContext as Items;
            MessagingCenter.Send<FancyLabel, Items>(this, "Edit", selectedItem);

        }

        public void HandleOnFling(object sender, EventArgs e)
        {
            EventHandler eventHandler = this.OnFlingActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            Items selectedItem = this.BindingContext as Items;
            MessagingCenter.Send<FancyLabel, Items>(this, "Delete", selectedItem);
        }

        public void HandleDoubleTap(object sender, EventArgs e)
        {
            //Handles the event from the SingleTap from the android renderer
            EventHandler eventHandler = this.DoubleTapActivated;
            eventHandler?.Invoke((object)this, EventArgs.Empty);
            //Sets selectedItem to the triggering item and sends the message out to be received by homepageview
            Items selectedItem = this.BindingContext as Items;
            MessagingCenter.Send<FancyLabel, Items>(this, "Edit", selectedItem);

        }
    }
}
