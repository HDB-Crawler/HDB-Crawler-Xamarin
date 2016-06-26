using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.ObjectModel;

namespace Skeleton.Droid
{
    public class CardViewFragment3 : Fragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        ItemListAdapter3 mAdapter;
        ItemList3 mItemList;

        ViewModel viewModel;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            // viewModel = new ViewModel();
            // Boolean success = await viewModel.GetActivitiesAsync();
            // ItemList.item = ConvertActivityToItem(viewModel.Activities);
            //mAdapter.NotifyDataSetChanged();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            // return base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.CardView, container, false);
            mItemList = new ItemList3();
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new ItemListAdapter3(mItemList);
            // mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

            return view;
        }

        void OnItemClick(object sender, int position)
        {
            Item3 item = mItemList[position];
            string[] Details = { item.title, item.description, item.attendees,
                item.date, item.time, item.venue };

            Intent readMoreIntent = new Intent(Activity, typeof(ReadMoreActivity));
            readMoreIntent.PutStringArrayListExtra("Details", Details);
            StartActivity(readMoreIntent);
        }
        
        public string title { get; set; }
        public string description { get; set; }
        public string attendees { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string venue { get; set; }

        public List<Item3> ConvertActivityToItem(ObservableCollection<Activity> activity)
        {
            List<Item3> items = new List<Item3>();
            for (int i = 0; i < activity.Count; i++)
            {
                items.Add(new Item3
                {
                    title = activity[i].title,
                    description = activity[i].description,
                    attendees = activity[i].members_attending,
                    date = activity[i].date,
                    time = activity[i].start_time,
                    venue = activity[i].venue
                });
            }
            return items;
        }
    }
    
    public class ItemListHolder3 : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }
        public TextView Description { get; private set; }
        public TextView Attendees { get; private set; }
        public TextView Date { get; private set; }
        public TextView Time { get; private set; }
        public TextView Venue { get; private set; }

        public ItemListHolder3(View itemView, Action<int> listener) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            Description = itemView.FindViewById<TextView>(Resource.Id.textViewDescription);
            Attendees = itemView.FindViewById<TextView>(Resource.Id.textViewAttendees);
            Date = itemView.FindViewById<TextView>(Resource.Id.textViewDate);
            Time = itemView.FindViewById<TextView>(Resource.Id.textViewTime);
            Venue = itemView.FindViewById<TextView>(Resource.Id.textViewVenue);

            // itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }

    public class ItemListAdapter3 : RecyclerView.Adapter
    {
        // public event EventHandler<int> ItemClick;

        public ItemList3 mItemList;
        public ItemListAdapter3(ItemList3 itemList)
        {
            mItemList = itemList;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.GoingLayout, parent, false);
            ItemListHolder3 vh = new ItemListHolder3(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemListHolder3 vh = holder as ItemListHolder3;
            vh.Title.Text = mItemList[position].title;
            // vh.Description.Text = mItemList[position].description;
            vh.Attendees.Text = mItemList[position].attendees + " people going";
            vh.Date.Text = mItemList[position].date;
            vh.Time.Text = mItemList[position].time;
            vh.Venue.Text = mItemList[position].venue;
        }

        public override int ItemCount
        {
            get { return mItemList.NumItems; }
        }
        
        void OnClick(int position)
        {
            //if (ItemClick != null)
            //    ItemClick(this, position);
        }
    }
    
    public class Item3
    {
        public string title { get; set; }
        public string description { get; set; }
        public string attendees { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string venue { get; set; }
    }

    public class ItemList3
    {
        public static List<Item3> item = new List<Item3>();

        public ItemList3()
        {
            item.Add(new Item3
            {
                title = "Prawning at Punggol",
                description = "Upcoming Punggol ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                attendees = "20",
                date = "27 June 2016",
                time = "12AM",
                venue = "Punggol Central"
            });
            /*
            item.Add(new Item3
            {
                title = "One-day trip to KL Farm",
                description = "Upcoming Durian ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                attendees = "100",
                date = "27 June 2016",
                time = "1AM",
                venue = "Punggol Central"
            });
            */
        }

        public int NumItems
        {
            get { return item.Count(); }
        }

        public Item3 this[int i]
        {
            get { return item[i]; }
        }
    }
}