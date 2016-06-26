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

namespace Skeleton.Droid
{
    public class CardViewFragment2 : Fragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        ItemListAdapter2 mAdapter;
        ItemList2 mItemList2;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.CardView, container, false);
            mItemList2 = new ItemList2();
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug in the linear layout manager:
            mLayoutManager = new LinearLayoutManager(Activity);
            mRecyclerView.SetLayoutManager(mLayoutManager);

            // Plug in my adapter:
            mAdapter = new ItemListAdapter2(mItemList2);
            mAdapter.ItemClick += OnItemClick;
            mRecyclerView.SetAdapter(mAdapter);

            return view;
        }

        void OnItemClick(object sender, int position)
        {
            Item2 item = mItemList2[position];
            string[] Details = { item.title, item.description, item.attendees,
                item.date, item.time, item.venue };

            Intent readMoreIntent = new Intent(Activity, typeof(ReadPastActivity));
            readMoreIntent.PutStringArrayListExtra("Details", Details);
            StartActivity(readMoreIntent);
        }
    }

    public class ItemListHolder2 : RecyclerView.ViewHolder
    {
        public TextView Title { get; private set; }
        public TextView Description { get; private set; }
        public TextView Attendees { get; private set; }
        public TextView Date { get; private set; }
        public TextView Time { get; private set; }
        public TextView Venue { get; private set; }

        public ItemListHolder2(View itemView, Action<int> listener) : base(itemView)
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

    public class ItemListAdapter2 : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;

        public ItemList2 mItemList2;
        public ItemListAdapter2(ItemList2 itemList)
        {
            mItemList2 = itemList;
        }

        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.ItemCardView, parent, false);
            ItemListHolder vh = new ItemListHolder(itemView, OnClick);
            return vh;
        }

        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ItemListHolder vh = holder as ItemListHolder;
            vh.Title.Text = mItemList2[position].title;
            // vh.Description.Text = mItemList2[position].description;
            vh.Attendees.Text = mItemList2[position].attendees + " people going";
            vh.Date.Text = mItemList2[position].date;
            vh.Time.Text = mItemList2[position].time;
            vh.Venue.Text = mItemList2[position].venue;
        }

        public override int ItemCount
        {
            get { return mItemList2.NumItems; }
        }

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

    public class Item2
    {
        public string title { get; set; }
        public string description { get; set; }
        public string attendees { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string venue { get; set; }
    }

    public class ItemList2
    {
        List<Item2> item = new List<Item2>();

        public ItemList2()
        {
            item.Add(new Item2
            {
                title = "Walk to Bond @ East Coast Part",
                description = "A 5km walk in the morning around Route A. Refreshment will be provided. Please contact connect@hdb.gov.sg for any queries.",
                attendees = "38",
                date = "27 June 2016",
                time = "12AM",
                venue = "East Coast Part"
            });
            item.Add(new Item2
            {
                title = "Chinese New Year Dinner",
                description = "Dinner at Punggol Hardcourt. Please contact connect@hdb.gov.sg for any queries.",
                attendees = "58",
                date = "27 June 2016",
                time = "1AM",
                venue = "Punggol Hardcourt"
            });
        }

        public int NumItems
        {
            get { return item.Count(); }
        }

        public Item2 this[int i]
        {
            get { return item[i]; }
        }
    }
}