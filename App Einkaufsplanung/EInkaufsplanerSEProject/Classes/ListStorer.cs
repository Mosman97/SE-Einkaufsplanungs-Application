using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace EInkaufsplanerSEProject.Classes
{
  class ListStorer
  {
    public ListStorer()
    {

    }

    public void StoreList()
    {
      FileStream fs = new FileStream(@"..\Assets\Lists.csv", FileMode.Open);
      StreamWriter file = new StreamWriter(fs);

      foreach (Shoppinglist item in CategoryListViewActivity.AllShoppinglists)
      {
        file.WriteLine(item.Name);
        foreach (Product prod in item.Products)
        {
          file.WriteLine(prod.Name + ";" + prod.Category + ";" + prod.Pos_x + ";" + prod.Pos_y);
        }
      }
      file.Close();
      fs.Close();

    }

    public void LoadList()
    {
      Shoppinglist list = new Shoppinglist(); 
      FileStream fs = new FileStream(@"..\Assets\Lists.csv", FileMode.Open);
      StreamReader file = new StreamReader(fs);
      string line = file.ReadLine();

      while (line != null)
      {
        if (!line.Contains(";")) // Wenn in der Zeile nur ein Objekt steht ist es ein Listenname. Somit haben wir den Beginn einer neuen Liste.
        {
          list = new Shoppinglist();
          list.Name = line;
          CategoryListViewActivity.AllShoppinglists.Add(list);
        }
        else // Wenn eine Zeile mindestens einen ; enthält, enthält sie Produkte, die zur aktuellen Liste addiert werden.
        {
          string[] zeile = line.Split(';');
          Product prod = new Product(zeile[0], zeile[1], Convert.ToInt32(zeile[2]), Convert.ToInt32(zeile[3]));
          list.addProduct(prod);
        }
      }
    }
  }
}