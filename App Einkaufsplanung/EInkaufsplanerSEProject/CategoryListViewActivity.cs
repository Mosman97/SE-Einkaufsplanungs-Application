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
using EInkaufsplanerSEProject.Classes;

namespace EInkaufsplanerSEProject
{
  [Activity(Label = "CategoryListViewActivity")]
  public class CategoryListViewActivity : Activity
  {
    private List<string> mItems;
    private ListView mListView;
    public static List<Shoppinglist> AllShoppinglists;
    private string prodName;
    string listName;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

            //Ctg-Name entpacken
            prodName = Intent.GetStringExtra("ctgName");
            //listName entpacken
            listName = Intent.GetStringExtra("listname");

            SetContentView(Resource.Layout.categorylist);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = prodName;
            

            //Load products from Database
            List<Classes.Product> prodList = Classes.Database.getProducts(prodName);
            prodName = Intent.GetStringExtra("ctgName");

            mListView = FindViewById<ListView>(Resource.Id.categoryListView);


            mItems = new List<string>();
            foreach (Classes.Product item in prodList)
            {
                mItems.Add(item.ToString());
            }


      CategoryListViewAdapter adapter = new CategoryListViewAdapter(this, mItems);

      mListView.Adapter = adapter;

        mListView.ItemClick += MListView_ItemClick;

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Needs implementation to write item to list and return to Shoppinglist listview
            string auswahl = mItems[e.Position];
            //Needs to load Product
            Classes.Product newProduct = Classes.Database.returnProduct(auswahl);
            //Load List (name = getStringExtra)
            Classes.Shoppinglist sl = Classes.ListStorer.LoadList(listName);
            //Needs to add Product to list 
            sl.addProduct(newProduct);
            //Store list
            Classes.ListStorer.StoreList(sl);
            //Parse back name
            Intent intent = new Intent(this, typeof(ListEditorActivity));
            intent.PutExtra("listname", listName);
            //Give controll to listeditoractivity
            this.StartActivity(intent);
        }
    }

  }
