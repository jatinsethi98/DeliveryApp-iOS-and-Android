
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
using Android.Support.Design.Widget;
using Android.Support.V4.App;

namespace DeliveryApp.Droid
{
    [Activity(Label = "TabsActivity")]

    public class TabsActivity : Android.Support.V4.App.FragmentActivity
    {
        TabLayout tabLayout;
        Android.Support.V7.Widget.Toolbar tabsToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Tabs);

            tabsToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tabToolbar);

            tabLayout = FindViewById<TabLayout>(Resource.Id.mainTabLayout);
            tabLayout.TabSelected += TabLayout_TabSelected;

            tabsToolbar.InflateMenu(Resource.Menu.tabsMenu);
            tabsToolbar.MenuItemClick += TabsToolbar_MenuItemClick;

            FragmentNavigate(new DeliveriesFragment());
        }

        private void TabsToolbar_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
           if (e.Item.ItemId == Resource.Id.action_add)
            {
                StartActivity(typeof(NewDeliveryActivity));
            }
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position)
            {
                case 0:
                    FragmentNavigate(new DeliveriesFragment());
                    break;
                case 1:
                    FragmentNavigate(new DeliveredFragment());
                    break;
                case 2:
                    FragmentNavigate(new ProfileFragment());
                    break;
            }
        }

        private void FragmentNavigate(Android.Support.V4.App.Fragment fragment)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame, fragment);
            transaction.Commit();
        }
    }
}