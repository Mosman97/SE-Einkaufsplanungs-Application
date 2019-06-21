using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EInkaufsplanerSEProject.Classes
{
  public class Shoppinglist
  {
    public List<Product> Products = new List<Product>();

    private string name_;

    public string Name { get { return name_; } set { name_ = value; } }

    public void addProduct(Product product)
    {
      Products.Add(product);
    }
  }
}