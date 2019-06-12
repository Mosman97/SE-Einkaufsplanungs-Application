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

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

            //Ctg-Name entpacken
            prodName = Intent.GetStringExtra("ctgName");
      SetContentView(Resource.Layout.categorylist);

      var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
      SetActionBar(toolbar);
      ActionBar.Title = "Listentitel";

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

      //Producte erstellen
      Classes.Product weihenstephanMilch = new Classes.Product("Weihenstephan Milch", "Milch");
      Classes.Product roggenBrot = new Classes.Product("Roggen Brot", "Brot");
      Classes.Product pinkLadyApfel = new Classes.Product("Pink Lady Apfel", "Apfel");

      mItems = new List<string>();
      mItems.Add(prodName);

      CategoryListViewAdapter adapter = new CategoryListViewAdapter(this, mItems);

      mListView.Adapter = adapter;

      //Shoppinglist aus den Produkten erstellen und speichern
      Shoppinglist list = new Shoppinglist();
      list.Name = "Meine Liste 1";
      list.addProduct(weihenstephanMilch);
      list.addProduct(roggenBrot);
      list.addProduct(pinkLadyApfel);

            mListView.ItemClick += MListView_ItemClick;

        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Needs implementation to write item to list and return to Shoppinglist listview
            string auswahl = mItems[e.Position];
            Console.WriteLine(mItems[e.Position]);
        }
    }

  }
