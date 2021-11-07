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
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android;
using Android.Support.Design.Widget;
using Android.Content.PM;


namespace DeliveryApp.Droid
{
    [Activity(Label = "NewDeliveryActivity")]
    public class NewDeliveryActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        View view;
        Button saveButton;
        EditText packageNameEditText;
        MapFragment mapFragment, destinationMapFragment;
        double latitude, longitude;
        LocationManager locationManager;
        GoogleMap originMap, destinationMap;
        public static int REQUEST_LOCATION = 99;

        public void OnLocationChanged(Location location)
        {
            latitude = location.Latitude;
            longitude = location.Longitude;
            mapFragment.GetMapAsync(this);

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            if (originMap == null)
                 originMap = googleMap;
             else
                 destinationMap = googleMap;

            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(latitude, longitude));
            marker.SetTitle("Your location");
            googleMap.AddMarker(marker);
        }

        public void OnProviderDisabled(string provider){}

        public void OnProviderEnabled(string provider){}

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras){}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if(requestCode == REQUEST_LOCATION)
            {
                if(grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                    GetLocationData();
            }
         }

         private void GetLocationData()
         {
             locationManager = GetSystemService(LocationService) as LocationManager;
             string provider = LocationManager.GpsProvider;

             if (locationManager.IsProviderEnabled(provider))
             {
                 locationManager.RequestLocationUpdates(provider, 5000, 1, this);
             }

             var location = locationManager.GetLastKnownLocation(provider);
             if (location != null)
             {
                 latitude = location.Latitude;
                 longitude = location.Longitude;
             }
             mapFragment.GetMapAsync(this);
             destinationMapFragment.GetMapAsync(this);
         }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);
            mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFragment);

            view = FindViewById(Android.Resource.Id.Content);

            saveButton.Click += SaveButton_Click;

            locationManager = GetSystemService(LocationService) as LocationManager;

        }
        protected override void OnResume()
        {
            base.OnResume();

            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == Permission.Denied)
            {
                if (ShouldShowRequestPermissionRationale(Manifest.Permission.AccessFineLocation))
                {
                    string[] permissions = { Manifest.Permission.AccessFineLocation };
                    Snackbar.Make(view, Resource.String.permission_location_rationale,
                Snackbar.LengthIndefinite).SetAction(Resource.String.ok, new Action<View>(delegate (View obj)
                {
                    ActivityCompat.RequestPermissions(this, permissions, REQUEST_LOCATION);
                })).Show();
                }
                else
                {
                    string[] permissions = { Manifest.Permission.AccessFineLocation };
                    RequestPermissions(permissions, REQUEST_LOCATION);
                }
             }
             else
                 GetLocationData();
        }

        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var originLocation = originMap.CameraPosition.Target;
            var destinationLocation = destinationMap.CameraPosition.Target;
            Delivery delivery = new Delivery()
            {
                Name = packageNameEditText.Text,
                Status = 0,
                OriginLatitude = originLocation.Latitude,
                OriginLongitude = originLocation.Longitude,
                DestinationLatitude = destinationLocation.Latitude,
                DestinationLongitude = destinationLocation.Longitude
            };
            await Delivery.InsertDelivery(delivery);
        }
    }
}
