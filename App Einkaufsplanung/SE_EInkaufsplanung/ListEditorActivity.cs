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
    [Activity(Label = "ListEditorActivity")]
    public class ListEditorActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.listeditor);

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
        }
    }
}