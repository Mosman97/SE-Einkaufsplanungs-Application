using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Content.Res;

namespace EInkaufsplanerSEProject
{
    [Activity(Label = "BitmapActivity")]
    class BitmapActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.bitmap_viewer);

            AssetManager assets = Android.App.Application.Context.Assets;

            //Classes.Pathfinding path = new Classes.Pathfinding();//Shoppinglist


            ImageView bitmap;
            bitmap = (ImageView)FindViewById(Resource.Id.marketpath);
            //System.IO.Stream si1 = assets.Open("Supermarket.bmp");
            //Bitmap bitmap1 = BitmapFactory.DecodeStream(si1);
            //Bitmap bitmap1 = path.FindPath();
            //Bitmap show = Bitmap.CreateScaledBitmap(bitmap1, 1200, 1300, true);
            //bitmap.SetImageBitmap(show);

        }

    }
}