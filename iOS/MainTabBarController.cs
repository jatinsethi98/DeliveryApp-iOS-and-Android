using Foundation;
using System;
using UIKit;

namespace DeliveryApp.iOS
{
    public partial class MainTabBarController : UITabBarController
    {
        public MainTabBarController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NavigationItem.SetHidesBackButton(true, true);
        }

        partial void UIBarButtonItem3586_Activated(UIBarButtonItem sender)
        {
            throw new NotImplementedException();
        }
    }
}