
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
using DeliveryApp.Droid;
using DeliveryApp.Model;

namespace DeliveriesApp.Droid
{
    class DeliveryAdapter : BaseAdapter
    {
        Context context;
        List<Delivery> deliveries;

        public DeliveryAdapter(Context context, List<Delivery> deliveries)
        {
            this.context = context;
            this.deliveries = deliveries;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            DeliveryAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as DeliveryAdapterViewHolder;

            if (holder == null)
            {
                holder = new DeliveryAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.DeliveryCell, parent, false);
                holder.Name = view.FindViewById<TextView>(Resource.Id.DeliveryNameTextView);
                holder.Status = view.FindViewById<TextView>(Resource.Id.DeliveryStatusTextView);
                view.Tag = holder;
            }


            //fill in your items
            var delivery = deliveries[position];
            holder.Name.Text = delivery.Name;
            switch (delivery.Status)
            {
                case 0:
                    holder.Status.Text = "Waiting for delivery person";
                    break;
                case 1:
                    holder.Status.Text = "Out for delivery";
                    break;
                case 2:
                    holder.Status.Text = "Delivered";
                    break;
            }

            return view;
        }

        //Fill in count here, currently 0
        public override int Count
        {
            get
            {
                return deliveries.Count;
            }
        }

    }

    class DeliveryAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Name { get; set; }
        public TextView Status { get; set; }
    }
}