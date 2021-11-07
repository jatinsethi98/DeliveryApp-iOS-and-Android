using Android.App;
using Android.Widget;
using Android.OS;
using DeliveryApp.Model;
using Android.Content;

namespace DeliveryPersonApp.Android
{
    [Activity(Label = "DeliveryPersonApp.Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            var userId = await DeliveryPerson.Login(emailEditText.Text, passwordEditText.Text);

            if (!string.IsNullOrEmpty(userId))
            {
                Intent intent = new Intent(this, typeof(TabsActivity));
                intent.PutExtra("userId", userId);
                StartActivity(intent);
            }
            else
                Toast.MakeText(this, "Failure", ToastLength.Long).Show();
        }
    }
}

