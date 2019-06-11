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

namespace EInkaufsplanerSEProject
{
    class AddItem_Dialog : DialogFragment
    {
        EditText ctgname;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.addItem_dialog, container, false);

            ctgname = view.FindViewById<EditText>(Resource.Id.ctgName);

            Button buttonctg = view.FindViewById<Button>(Resource.Id.choose_product);

            //Add Click-Event to Button
            buttonctg.Click += (object sender, EventArgs e) =>
            {
                string name = ctgname.Text;

                Intent intent = new Intent(Context, typeof(CategoryListViewActivity));
                intent.PutExtra("ctgName", name);
                this.StartActivity(intent);
            };

            return view;
        }

    }
}