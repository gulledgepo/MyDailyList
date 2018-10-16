using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MDL.Interfaces;
using MDL.Models;
using Xamarin.Forms;

namespace MDL.Droid
{
    public class FancyGestureListener : GestureDetector.SimpleOnGestureListener
    {
        public FancyLabel myLabel { private get; set; }

        public override void OnLongPress( MotionEvent e)
        {
            //Items selectedItem = ((string)sender.BindingContext as Items;
            Console.WriteLine("OnLongPress");
            base.OnLongPress(e);

            if (myLabel != null)
            {
                myLabel.HandleLongPress(this, new System.EventArgs());
            }
            //var selectedItem = (FancyLabel)e.sender

        }

        public override bool OnDoubleTap(MotionEvent e)
        {
            Console.WriteLine("OnDoubleTap");
            return base.OnDoubleTap(e);
        }

        public override bool OnDoubleTapEvent(MotionEvent e)
        {
            Console.WriteLine("OnDoubleTapEvent");
            return base.OnDoubleTapEvent(e);
        }

        public override bool OnSingleTapUp(MotionEvent e)
        {
            Console.WriteLine("OnSingleTapUp");
            if (myLabel != null)
            {
                myLabel.HandleSingleTapUp(this, new System.EventArgs());
            }
            return base.OnSingleTapUp(e);


        }

        public override bool OnDown(MotionEvent e)
        {
            Console.WriteLine("OnDown");
            return base.OnDown(e);
        }

        public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            Console.WriteLine("OnFling");
            if (myLabel != null)
            {
                myLabel.HandleOnFling(this, new System.EventArgs());
            }
            return base.OnFling(e1, e2, velocityX, velocityY);
        }

        //public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        //{
        //    Console.WriteLine("OnScroll");
        //    return base.OnScroll(e1, e2, distanceX, distanceY);
        //}

        public override void OnShowPress(MotionEvent e)
        {
            Console.WriteLine("OnShowPress");
            base.OnShowPress(e);
        }

        public override bool OnSingleTapConfirmed(MotionEvent e)
        {
            Console.WriteLine("OnSingleTapConfirmed");
            //if (myLabel != null)
            //{
            //    myLabel.HandleSingleTap(this, new System.EventArgs());
            //}
            return base.OnSingleTapConfirmed(e);

        }

    }
}