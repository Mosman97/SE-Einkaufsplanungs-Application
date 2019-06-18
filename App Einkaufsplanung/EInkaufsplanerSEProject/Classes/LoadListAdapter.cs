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
    class LoadListAdapter : BaseAdapter<string>
    {

        private List<string> mItems;
        private Context mContext;
        protected Activity Context = null;

        public LoadListAdapter(Activity context, List<string> items)
        {
            mItems = items;
            mContext = context;
            this.Context = context;
        }

        public override int Count { get { return mItems.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position] //muss angepasst werden an das Objekt (Später Product statt string)
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent) //https://youtu.be/OHvY1DUxzfo?t=475
        {
            View row = convertView;

            if (row == null)
            {
                row = Context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.loadlistrow, null, false);
            }



            TextView Name = row.FindViewById<TextView>(Resource.Id.listName);
            Name.Text = mItems[position];

            return row;

        }
    }
}