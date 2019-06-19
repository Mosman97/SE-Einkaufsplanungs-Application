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
        public static List<Product> getProducts(string eingabe)
        {
            List<Product> rProducts = new List<Product>();

            AssetManager assets = Android.App.Application.Context.Assets;

            using (var reader = new StreamReader(assets.Open("database.csv")))
            using (var csv = new CsvReader(reader))
            {
                //rProducts = csv.GetRecords<Product>();
                csv.Configuration.Delimiter = ";";


                csv.Read();
                csv.ReadHeader();

                while(csv.Read())
                {
                    Product record = new Product
                    {
                        Category = csv.GetField(0),
                        Name = csv.GetField(1),
                        Pos_x = csv.GetField<int>(2),
                        Pos_y = csv.GetField<int>(3)
                    };

                    if(eingabe == record.Category)
                    {
                        rProducts.Add(record);
                    }

                }
                
            }

            return rProducts;
        }

        public static Product returnProduct(string name)
        {
            Product produkt = new Product();

            AssetManager assets = Android.App.Application.Context.Assets;

            using (var reader = new StreamReader(assets.Open("database.csv")))
            using (var csv = new CsvReader(reader))
            {
                //rProducts = csv.GetRecords<Product>();
                csv.Configuration.Delimiter = ";";


                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    Product record = new Product
                    {
                        Category = csv.GetField(0),
                        Name = csv.GetField(1),
                        Pos_x = csv.GetField<int>(2),
                        Pos_y = csv.GetField<int>(3)
                    };

                    if (name == record.Category)
                    {
                        produkt = record;
                        break;
                    }

                }

            }

            return produkt;
        }
    }
}