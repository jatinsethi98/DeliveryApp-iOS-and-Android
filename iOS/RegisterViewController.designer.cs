// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DeliveryApp.iOS
{
    [Register ("RegisterViewController")]
    partial class RegisterViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton registerButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField registerConfirmPasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField registerEmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField registerPasswordTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (registerButton != null) {
                registerButton.Dispose ();
                registerButton = null;
            }

            if (registerConfirmPasswordTextField != null) {
                registerConfirmPasswordTextField.Dispose ();
                registerConfirmPasswordTextField = null;
            }

            if (registerEmailTextField != null) {
                registerEmailTextField.Dispose ();
                registerEmailTextField = null;
            }

            if (registerPasswordTextField != null) {
                registerPasswordTextField.Dispose ();
                registerPasswordTextField = null;
            }
        }
    }
}