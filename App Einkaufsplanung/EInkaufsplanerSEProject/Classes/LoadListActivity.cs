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

namespace EInkaufsplanerSEProject
{
    [Activity(Label = "LoadListActivity")]
    public class LoadListActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.loadlistview);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Load list";

            //Load products from File/s here
            mItems = Classes.ListStorer.loadListNames();
            

            mListView = FindViewById<ListView>(Resource.Id.loadListListView);

            LoadListAdapter adapter = new LoadListAdapter(this, mItems);

            mListView.Adapter = adapter;

            //mListView.ItemClick += MListView_ItemClick;

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Needs implementation to write item to list and return to Shoppinglist listview
            string auswahl = mItems[e.Position];
            Console.WriteLine(mItems[e.Position]);
        }
    }
}