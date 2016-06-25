using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.App;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;

namespace Skeleton.Droid
{
    // public class FormFragment : Fragment
    [Activity(Label = "Details", Theme = "@style/MyTheme")]
    public class FormFragment : AppCompatActivity
    {
        Button buttonSubmit;
		ViewModel viewModel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Form);

            // Create your fragment here
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            buttonSubmit = FindViewById<Button>(Resource.Id.buttonSubmit);
			buttonSubmit.Click += async (sender, e) =>
            {
                //Intent intent = new Intent();
                /*
                alert.SetTitle("Your feedback has been recorded in our database.");
                RunOnUiThread(() => {
                    alert.Show();
                });
                */
                viewModel = new ViewModel();
				Boolean success = await viewModel.SetFeedback("Good");
                RunOnUiThread(() => {
                    Toast.MakeText(this.ApplicationContext, "Your response has been recorded.",
                        ToastLength.Long).Show();
                });
                Finish();
            };
        }
    }
}