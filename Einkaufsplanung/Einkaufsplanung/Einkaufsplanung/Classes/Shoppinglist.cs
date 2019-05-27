using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Einkaufsplanung.Classes
{ 
    class Shoppinglist
    {

        private string listname_;

        public List<Product> produkte_ = new List<Product>();
        public static void SaveList(string name)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
        }

        public static void LoadList(string name)
        {
            
        }

        public static void DeleteList(string name)
        {
            
        }

        public void AddProduct(Product product)
        {
            produkte_.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            produkte_.Remove(product);
        }
    }
}
