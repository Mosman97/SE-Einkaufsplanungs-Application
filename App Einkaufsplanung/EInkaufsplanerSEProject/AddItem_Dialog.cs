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
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.addItem_dialog, container, false);

            Button button = view.FindViewById<Button>(Resource.Id.addItem_dbutton);

            button.Click += addItem_Click;

            return view;
        }

        private void addItem_Click(object sender, EventArgs e)
        {

        }
    }
}