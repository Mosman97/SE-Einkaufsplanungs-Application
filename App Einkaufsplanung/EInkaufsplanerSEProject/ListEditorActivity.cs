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
        private Classes.Shoppinglist shoppinglist;
        string listname;
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

            //Ctg-Name entpacken
            listname = Intent.GetStringExtra("listname");

            SetContentView(Resource.Layout.listeditor);

            
            //check if a shoppinglist-name was given
            if (listname != null)
            {
                //Check if a list already exists
                shoppinglist = Classes.ListStorer.LoadList(listname);
                if (shoppinglist == null)
                {
                    //Create new shoppinglist
                    shoppinglist = new Classes.Shoppinglist();
                    shoppinglist.Name = listname;
                }
            }
            else
            {
                throw new ArgumentException("Missing list name");
            }
            

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = listname;



            mListView = FindViewById<ListView>(Resource.Id.myListView);

            mItems = new List<string>();
            if (shoppinglist.Products != null)
            {
                //Produkte von Shoppinglist in mItems schreiben
                foreach (Classes.Product item in shoppinglist.Products)
                {
                    mItems.Add(item.ToString());
                }
            }
            

            /*
            mItems = new List<string>();
            mItems.Add("Weihenstephan Milch");
            mItems.Add("Roggen Brot");
            mItems.Add("Pink Lady Apfel");
            */

            MyListViewAdapter adapter = new MyListViewAdapter(this, mItems);

            mListView.Adapter = adapter;


            Button addItem;
            addItem = FindViewById<Button>(Resource.Id.newItem);
            addItem.Click += addbtn_Click;

            Button startpath;
            startpath = FindViewById<Button>(Resource.Id.startpath);
            startpath.Click += pathfinding_Click;
        }

        void addbtn_Click(object sender, EventArgs e)
        {
            
            FragmentTransaction transcation = FragmentManager.BeginTransaction();
            AddItem_Dialog addItem_Dialog = new AddItem_Dialog();
            addItem_Dialog.getName(listname);
            Classes.ListStorer.StoreList(shoppinglist);
            addItem_Dialog.Show(transcation, "dialog fragment");
        }

        void pathfinding_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(BitmapActivity));
            intent.PutExtra("Lname", listname);
            this.StartActivity(intent);
        }
    }
}