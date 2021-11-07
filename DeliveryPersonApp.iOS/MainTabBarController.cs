using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class MainTabBarController : UITabBarController
    {
        public string userId;
        public MainTabBarController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationItem.SetHidesBackButton(true, false);
            
            var deliveringVC = ViewControllers[0] as DeliveringTableViewController;
            deliveringVC.userId = userId;

            var waitingVC = ViewControllers[1] as WaitingTableViewController;
            waitingVC.userId = userId;

            var deliveredVC = ViewControllers[2] as DeliveredTableViewController;
            deliveredVC.userId = userId;
        }
    }
}