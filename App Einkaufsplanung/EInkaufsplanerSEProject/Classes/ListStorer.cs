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
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "lists.csv");

            if (File.Exists(filename) == false)
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                fs.Close();
            }

            //if (shoplist.Products != null)
            //{
            // Erst alle Shoppinglisten einlesen
            List<Shoppinglist> Listen = new List<Shoppinglist>();
            List<string> Names = loadListNames();
            foreach (string nam in Names)
            {
                Listen.Add(LoadList(nam));
            }

            //Alle Listen bis auf die geänderte in die Datei schreiben
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Shoppinglist shp in Listen)
                {
                    if (shp.Name != shoplist.Name) // geänderte Datei wird nicht geschrieben
                    {
                        sw.WriteLine(shp.Name);
                        if (shp.Products != null)
                        {
                            foreach (Product prod in shp.Products)
                            {
                                sw.WriteLine(prod.Name + ";" + prod.Category + ";" + prod.Pos_x + ";" + prod.Pos_y);
                            }
                        }
                    }
                }

                // Als letztes wird die geänderte Liste wieder in die Datei schreiben
                sw.WriteLine(shoplist.Name);
                if (shoplist.Products != null)
                {
                    foreach (Product prod in shoplist.Products)
                    {
                        sw.WriteLine(prod.Name + ";" + prod.Category + ";" + prod.Pos_x + ";" + prod.Pos_y);
                    }
                }
            }
            //}
        }

        public static List<string> loadListNames()
        {
            List<string> listnames = new List<string>();
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "lists.csv");

            if (File.Exists(filename) == false)
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                fs.Close();
            }

            using (StreamReader sr = new StreamReader(filename))
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
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "lists.csv");

            if (File.Exists(filename) == false)
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                fs.Close();
            }

            Shoppinglist list = new Shoppinglist();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    if (line == listName) //Liste mit dem eingegebenen Namen suchen
                    {
                        list = new Shoppinglist();
                        list.Name = line;
                        line = sr.ReadLine();

                        while (line != null && line.Contains(";"))
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