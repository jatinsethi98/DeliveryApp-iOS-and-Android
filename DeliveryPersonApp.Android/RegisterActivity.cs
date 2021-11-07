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
using DeliveryApp.Model;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.registerConfirmEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerSaveButton);

            registerButton.Click += RegisterButton_Click;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            var success = await DeliveryPerson.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);

            if (success)
                Toast.MakeText(this, "Success", ToastLength.Long).Show();
            else
                Toast.MakeText(this, "Failure", ToastLength.Long).Show();
        }
    }
}