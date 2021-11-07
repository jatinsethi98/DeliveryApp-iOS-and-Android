using System.Linq;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using DeliveryApp.Model;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Droid
{
    [Activity(Label = "DeliveryApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        EditText Email, Password;
        Button signinButton, registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Email = FindViewById<EditText>(Resource.Id.emailEditText);
            Password = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signInButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;

        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", Email.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            var email = Email.Text;
            var password = Password.Text;

            var result = await Post.Login(email, password);

            if (result)
            {
                Toast.MakeText(this, "Login Successful!", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(TabsActivity));
                StartActivity(intent);
                Finish();
            }
            else
                Toast.MakeText(this, "Please try again", ToastLength.Long).Show();
            
        }
    }
}

