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
    [Activity(Label = "CategoryListViewActivity")]
    public class CategoryListViewActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;
        private string prodName;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.categorylist);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Listentitel";

            prodName = Intent.GetStringExtra("ctgName");

            mListView = FindViewById<ListView>(Resource.Id.categoryListView);



            //Producte erstellen
            Classes.Product weihenstephanMilch = new Classes.Product("Weihenstephan Milch", "Milch");
            Classes.Product roggenBrot = new Classes.Product("Roggen Brot", "Brot");
            Classes.Product pinkLadyApfel = new Classes.Product("Pink Lady Apfel", "Apfel");

            mItems = new List<string>();
            mItems.Add(prodName);

            CategoryListViewAdapter adapter = new CategoryListViewAdapter(this, mItems);

            mListView.Adapter = adapter;

        }

    }
}