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
using Android.Util;


namespace EInkaufsplanerSEProject
{
    class CreateList_Dialog : DialogFragment
    {
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.createlist_dialog, container, false);

            Button button = view.FindViewById<Button>(Resource.Id.createbutton_dialog);

            button.Click += creatlist_Click;

            return view;
        }

        private void creatlist_Click(object sender, EventArgs e)
        {
                //Namen übergeben und Liste erstellen!
                Intent intent = new Intent(Context, typeof(ListEditorActivity));
                this.StartActivity(intent);
        }
    }
}