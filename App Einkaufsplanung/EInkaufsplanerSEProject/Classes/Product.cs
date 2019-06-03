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

namespace EInkaufsplanerSEProject.Classes
{
    class Product
    {
        private string name_;
        private string category_;

        public string Name { get { return name_; }  set { name_ = value; } }

        public string category { get { return category_; } set { category_ = value; } }

        public Product(string name, string category)
        {
            name_ = name;
            category_ = category;
        }

        public override string ToString()
        {
            return name_;
        }

    }
}