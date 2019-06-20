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

    public static void StoreList(Shoppinglist shoplist)
    {
      AssetManager assets = Android.App.Application.Context.Assets;

      // Erst alle Shoppinglisten einlesen
      List<Shoppinglist> Listen = new List<Shoppinglist>();
      List<string> Names = loadListNames();
      foreach (string nam in Names)
      {
        Listen.Add(LoadList(nam));
      }

      //Alle Listen bis auf die geänderte in die Datei schreiben
      using (StreamWriter sw = new StreamWriter(assets.Open("lists.csv")))
      {
        foreach (Shoppinglist shp in Listen)
        {
          if (shp.Name != shoplist.Name) // geänderte Datei wird nicht geschrieben
          {
            sw.WriteLine(shp.Name);
            foreach (Product prod in shp.Products)
            {
              sw.WriteLine(prod.Name + ";" + prod.Category + ";" + prod.Pos_x + ";" + prod.Pos_y);
            }
          }
        }

        // Als letztes wird die geänderte Liste wieder in die Datei schreiben
        sw.WriteLine(shoplist.Name);
        foreach (Product prod in shoplist.Products)
        {
          sw.WriteLine(prod.Name + ";" + prod.Category + ";" + prod.Pos_x + ";" + prod.Pos_y);
        }
      }
    }

    public static List<string> loadListNames()
    {
      List<string> listnames = new List<string>();
      AssetManager assets = Android.App.Application.Context.Assets;
      using (StreamReader sr = new StreamReader(assets.Open("lists.csv")))
      {
        string line = sr.ReadLine();

        while (line != null)
        {
          if (!line.Contains(";")) // Wenn in der Zeile nur ein Objekt steht ist es ein Listenname. Somit haben wir den Beginn einer neuen Liste.
          {
            listnames.Add(line);
          }
          line = sr.ReadLine();
        }
      }
      return listnames;
    }

    public static Shoppinglist LoadList(string listName)
    {
      AssetManager assets = Android.App.Application.Context.Assets;

      Shoppinglist list = new Shoppinglist();

      using (StreamReader sr = new StreamReader(assets.Open("lists.csv")))
      {
        string line = sr.ReadLine();

        while (line != null)
        {
          if (line == listName) //Liste mit dem eingegebenen Namen suchen
          {
            list = new Shoppinglist();
            list.Name = line;
            line = sr.ReadLine();

            while (line.Contains(";"))
            {
              string[] zeile = line.Split(';');
              Product prod = new Product(zeile[0], zeile[1], Convert.ToInt32(zeile[2]), Convert.ToInt32(zeile[3]));
              list.addProduct(prod);
            } // Wenn die Zeile keinen ; mehr enthält beginnt eine neue Liste
            line = sr.ReadLine();
            return list;
          }
          line = sr.ReadLine();
        }
        return null; // Wenn die Liste nicht gefunden wurde
      }
    }
  }
}