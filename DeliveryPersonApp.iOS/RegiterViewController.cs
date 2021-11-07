using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class RegiterViewController : UIViewController
    {
        public RegiterViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            registerSaveButton.TouchUpInside += RegisterSaveButton_TouchUpInside;
        }

        private async void RegisterSaveButton_TouchUpInside(object sender, EventArgs e)
        {
            bool success = await DeliveryPerson.Register(emailTextField.Text, passwordTextField.Text, confirmPasswordTextField.Text);

            UIAlertController alert = null;
            if (success)
                alert = UIAlertController.Create("Success", "New user has been registered", UIAlertControllerStyle.Alert);
            else
                alert = UIAlertController.Create("Failure", "Something went wrong when registering the user, please try again", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}