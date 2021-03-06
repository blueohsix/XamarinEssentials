﻿using Android.App;
using Android.Widget;
using Android.OS;
using TrainingRooms;
using Android.Content;
using Android.Views;

namespace trainingrooms.droid
{
    [Activity(Label = "trainingrooms.droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var repo = new RoomRepository();
            var rooms = repo.GetRooms();
            var adapter = new ArrayAdapter<TrainingRoom>(this, Resource.Layout.RoomListItem, rooms.ToArray());

            this.ListAdapter = adapter;
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var intent = new Intent(this, typeof(TrainingRoomDetailActivity));
            var selectedItem = ((ArrayAdapter<TrainingRoom>)ListAdapter).GetItem(position);
            intent.PutExtra("roomId", selectedItem.Id);
            StartActivity(intent);
        }
    }
}

