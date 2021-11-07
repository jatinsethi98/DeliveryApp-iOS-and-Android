
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Droid;
using DeliveryApp.Model;

namespace DeliveryApp.Droid
{
    public class DeliveriesFragment : Android.Support.V4.App.ListFragment
    {
        public async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            var deliveries = await Delivery.GetDeliveries();
            ListAdapter = new DeliveryAdapter(Activity, deliveries);
        }
    }
}
