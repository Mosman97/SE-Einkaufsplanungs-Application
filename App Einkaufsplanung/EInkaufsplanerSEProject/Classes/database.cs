using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.Res;

using CsvHelper;

namespace EInkaufsplanerSEProject.Classes
{
    class Database
    {
        /// <summary>
        /// Nach der Eingabe was der Nutzer einkaufen will, werden alle Produkte in einer Liste zurückgegeben, die in der DAtenbank gefunden wurden
        /// </summary>
        /// <param name="eingabe"></param>
        /// <returns></returns>
        public List<Product> getProducts(string eingabe)
        {
            List<Product> rProducts = new List<Product>();

            AssetManager assets = Android.App.Application.Context.Assets;

            using (var reader = new StreamReader(assets.Open("database.csv")))
            using (var csv = new CsvReader(reader))
            {

                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    Product record = new Product
                    {
                        category = csv.GetField("Category"),
                        Name = csv.GetField("Name"),
                        Pos_x = csv.GetField<int>("x"),
                        Pos_y = csv.GetField<int>("y"),
                    };

                    if(eingabe == record.category)
                    {
                        rProducts.Add(record);
                    }

                }
            }

            return rProducts;
        }
    }
}