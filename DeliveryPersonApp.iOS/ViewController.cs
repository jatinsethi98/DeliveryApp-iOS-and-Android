using DeliveryApp.Model;
using System;

using UIKit;
using Foundation;

namespace DeliveryPersonApp.iOS
{
    public partial class ViewController : UIViewController
    {
        bool hasLoggedin = false;
        string userId = string.Empty;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            signinButton.TouchUpInside += SigninButton_TouchUpInside;
        }

        private async void SigninButton_TouchUpInside(object sender, EventArgs e)
        {
            userId = await DeliveryPerson.Login(emailTextField.Text, passwordTextField.Text);

            if(string.IsNullOrEmpty(userId))
            {

            }
            else
            {
                hasLoggedin = true;
                PerformSegue("loginSegue", this);
            }
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if(segueIdentifier == "loginSegue")
            {
                return hasLoggedin;
            }

            return true;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if(segue.Identifier == "loginSegue")
            {
                var destinationVC = segue.DestinationViewController as MainTabBarController;
                destinationVC.userId = userId;
            }

            base.PrepareForSegue(segue, sender);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}