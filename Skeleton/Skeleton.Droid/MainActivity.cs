using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Views;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/app_id")]
[assembly:Permission (Name = Android.Manifest.Permission.Internet)]
[assembly:Permission (Name = Android.Manifest.Permission.WriteExternalStorage)]
namespace Skeleton.Droid
{
	[Activity (Label = "HDB", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        ViewModel viewModel;
        public static int VALUE = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            SetContentView(Resource.Layout.Main);

            var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
                setupViewPager(viewPager);

            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            // StartActivity(typeof(LoginActivity));
            // viewModel = new ViewModel();
            // Boolean success = await viewModel.GetActivitiesAsync();
        }

        void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
        {
            var adapter = new Adapter(SupportFragmentManager);
            // adapter.AddFragment(new FacebookLoginFragment(), "FacebookLogin");
            adapter.AddFragment(new CardViewFragment(), "Upcoming Events");
            // adapter.AddFragment(new ListViewFragment(), "Listview");
            adapter.AddFragment(new CardViewFragment3(), "Going");
            adapter.AddFragment(new CardViewFragment2(), "Past Events");
            // adapter.AddFragment(new FormFragment(), "Form");
            // adapter.AddFragment(new CardViewFragment3(), "Going");
            viewPager.Adapter = adapter;
        }

        class Adapter : Android.Support.V4.App.FragmentPagerAdapter
        {
            List<V4Fragment> fragments = new List<V4Fragment>();
            List<string> fragmentTitles = new List<string>();

            public Adapter(V4FragmentManager fm) : base(fm)
            {
            }

            public void AddFragment(V4Fragment fragment, String title)
            {
                fragments.Add(fragment);
                fragmentTitles.Add(title);
            }

            public override V4Fragment GetItem(int position)
            {
                return fragments[position];
            }

            public override int Count
            {
                get { return fragments.Count; }
            }

            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(fragmentTitles[position]);
            }
        }
    }
}


