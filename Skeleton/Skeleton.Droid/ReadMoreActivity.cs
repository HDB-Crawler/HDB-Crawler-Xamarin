using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Support.V7.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Widget;

namespace Skeleton.Droid
{
    [Activity(Label = "Details", Theme = "@style/MyTheme")]
    public class ReadMoreActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ReadMoreView);

            
            TextView tvTitle = FindViewById<TextView>(Resource.Id.textViewTitle);
            TextView tvDescription = FindViewById<TextView>(Resource.Id.textViewDescription);
            TextView tvAttendees = FindViewById<TextView>(Resource.Id.textViewAttendees);
            TextView tvDate = FindViewById<TextView>(Resource.Id.textViewDate);
            TextView tvTime = FindViewById<TextView>(Resource.Id.textViewTime);
            TextView tvVenue = FindViewById<TextView>(Resource.Id.textViewVenue);
            Button btnRSVP = FindViewById<Button>(Resource.Id.buttonRSVP);

            IList<string> Details = Intent.Extras.GetStringArrayList("Details");
            string Title = Details[0];
            string Description = Details[1];
            string Attendees = Details[2] + " people going";
            string Date = Details[3];
            string Time = Details[4];
            string Venue = Details[5];

            tvTitle.Text = Title;
            tvDescription.Text = Description;
            tvAttendees.Text = Attendees;
            tvDate.Text = Date;
            tvTime.Text = Time;
            tvVenue.Text = Venue;

            btnRSVP.Click += delegate
            {
                MainActivity.VALUE = 1;
                this.Finish();
            };
        }
    }
}