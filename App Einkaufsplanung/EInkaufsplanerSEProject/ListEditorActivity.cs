﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EInkaufsplanerSEProject
{
    [Activity(Label = "ListEditorActivity")]
    public class ListEditorActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        //Custom Menübar mit Save Icon
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        //Wenn user save tapped erscheint eine Meldung:
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.listeditor);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Listentitel";



            mListView = FindViewById<ListView>(Resource.Id.myListView);



            //Producte erstellen
            Classes.Product weihenstephanMilch = new Classes.Product("Weihenstephan Milch", "Milch");
            Classes.Product roggenBrot = new Classes.Product("Roggen Brot", "Brot");
            Classes.Product pinkLadyApfel = new Classes.Product("Pink Lady Apfel", "Apfel");

            mItems = new List<string>();
            mItems.Add("Weihenstephan Milch");
            mItems.Add("Roggen Brot");
            mItems.Add("Pink Lady Apfel");

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;


            Button addItem;
            addItem = FindViewById<Button>(Resource.Id.newItem);
            addItem.Click += addbtn_Click;
        }

        void addbtn_Click(object sender, EventArgs e)
        {
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            AddItem_Dialog addItem_Dialog = new AddItem_Dialog();
            addItem_Dialog.Show(transcation, "dialog fragment");
        }
    }
}