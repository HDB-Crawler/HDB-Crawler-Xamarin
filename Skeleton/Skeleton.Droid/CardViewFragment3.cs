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
        ItemListAdapter mAdapter;
        ItemList mItemList;

        ViewModel viewModel;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            viewModel = new ViewModel();
            Boolean success = await viewModel.GetActivitiesAsync();
            ItemList.item = ConvertActivityToItem(viewModel.Activities);
            mAdapter.NotifyDataSetChanged();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            // return base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.CardView, container, false);
            mItemList = new ItemList();
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new ItemListAdapter(mItemList);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

            return view;
        }

        void OnItemClick(object sender, int position)
        {
            Item item = mItemList[position];
            string[] Details = { item.title, item.description, item.attendees,
                item.date, item.time, item.venue };

            Intent readMoreIntent = new Intent(Activity, typeof(ReadMoreActivity));
            readMoreIntent.PutStringArrayListExtra("Details", Details);
            StartActivity(readMoreIntent);
        }

        /*
        public string title { get; set; }
        public string description { get; set; }
        public string attendees { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string venue { get; set; }
        */

        public List<Item> ConvertActivityToItem(ObservableCollection<Activity> activity)
        {
            List<Item> items = new List<Item>();
            for (int i = 0; i < activity.Count; i++)
            {
                items.Add(new Item
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

    /*
    public class ItemListHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }
        public TextView Description { get; private set; }
        public TextView Attendees { get; private set; }
        public TextView Date { get; private set; }
        public TextView Time { get; private set; }
        public TextView Venue { get; private set; }

        public ItemListHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.textViewTitle);
            Description = itemView.FindViewById<TextView>(Resource.Id.textViewDescription);
            Attendees = itemView.FindViewById<TextView>(Resource.Id.textViewAttendees);
            Date = itemView.FindViewById<TextView>(Resource.Id.textViewDate);
            Time = itemView.FindViewById<TextView>(Resource.Id.textViewTime);
            Venue = itemView.FindViewById<TextView>(Resource.Id.textViewVenue);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
    */

    public class ItemListAdapter3 : ItemListAdapter
    {
        public event EventHandler<int> ItemClick;

        // public ItemList mItemList;
        public ItemListAdapter3(ItemList itemList) : base(itemList)
        {
            base.mItemList = itemList;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.GoingLayout, parent, false);
            ItemListHolder vh = new ItemListHolder(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemListHolder vh = holder as ItemListHolder;
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
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

    /*
    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string attendees { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string venue { get; set; }
    }

    public class ItemList
    {
        public static List<Item> item = new List<Item>();

        public ItemList()
        {
        }

        public int NumItems
        {
            get { return item.Count(); }
        }

        public Item this[int i]
        {
            get { return item[i]; }
        }
    } */
}