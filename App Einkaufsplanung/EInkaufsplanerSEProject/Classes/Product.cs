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
  public class Product
  {
    private string name_;
    private string category_;
    private int pos_x_;
    private int pos_y_;

    public string Name { get { return name_; } set { name_ = value; } }

    public string category { get { return category_; } set { category_ = value; } }

    public int Pos_x { get { return pos_x_; } set { pos_x_ = value; } }

    public int Pos_y { get { return pos_y_; } set { pos_y_ = value; } }

    public Product(string name, string category, int x, int y) //Wird beim Dynamischen einlesen der Daten aus der Datei gebraucht
    {
      name_ = name;
      category_ = category;
      Pos_x = x;
      Pos_y = y;
    }

    public Product(string name, string category) //Obsolet wenn alles dynamisch läuft
    {
      name_ = name;
      category_ = category;
    }

    public Product(string name)
    {
      name_ = name;
    }

    public Product() { }

    public override string ToString()
    {
      return name_;
    }

  }
}