using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MDL.Droid;
using MDL;

//[assembly: ExportRenderer(typeof(Label), typeof(FancyLabel))]
[assembly: ExportRenderer(typeof(FancyLabel), typeof(FancyAndroidLabelRenderer))]

namespace MDL.Droid
{

    public class FancyAndroidLabelRenderer : LabelRenderer
    {
        FancyLabel label;
        private readonly FancyGestureListener _listener;
        private readonly GestureDetector _detector;

        public FancyAndroidLabelRenderer()
        {
            _listener = new FancyGestureListener();
            _detector = new GestureDetector(_listener);
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement == null)
        //    {
        //        this.GenericMotion -= HandleGenericMotion;
        //        this.Touch -= HandleTouch;
        //    }

        //    if (e.OldElement == null)
        //    {
        //        this.GenericMotion += HandleGenericMotion;
        //        this.Touch += HandleTouch;
        //    }

        //}

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                label = e.NewElement as FancyLabel;
                UpdateEventHandlers();
            }
        }

        private void UpdateEventHandlers()
        {
            _listener.myLabel = label;

            GenericMotion += (s, a) => _detector.OnTouchEvent(a.Event);
            Touch += (s, a) => _detector.OnTouchEvent(a.Event);
        }


        void HandleTouch(object sender, TouchEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }

        void HandleGenericMotion(object sender, GenericMotionEventArgs e)
        {
            _detector.OnTouchEvent(e.Event);
        }
    }
}