using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;
using CoreLocation;
using MapKit;

namespace DeliveryApp.iOS
{
    public partial class NewDeliveryViewController : UIViewController
    {
        CLLocationManager locationManager;
        public NewDeliveryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            originMapView.ShowsUserLocation = true;
            destinationMapView.ShowsUserLocation = true;

            originMapView.DidUpdateUserLocation += OriginMapView_DidUpdateUserLocation;
            destinationMapView.DidUpdateUserLocation += DestinationMapView_DidUpdateUserLocation;

            saveBarButtonItem.Clicked += SaveBarButtonItem_Clicked;
        }

        private void DestinationMapView_DidUpdateUserLocation(object sender, MKUserLocationEventArgs e)
        {
            if (destinationMapView.UserLocation != null)
            {
                var coordinates = destinationMapView.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(0.15, 0.15);
                destinationMapView.Region = new MKCoordinateRegion(coordinates, span);

                destinationMapView.RemoveAnnotations();
                destinationMapView.AddAnnotation(new MKPointAnnotation()
                {
                    Coordinate = coordinates,
                    Title = "Your location"
                });
            }
        }

        private void OriginMapView_DidUpdateUserLocation(object sender, MKUserLocationEventArgs e)
        {
            if (originMapView.UserLocation != null)
            {
                var coordinates = originMapView.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(0.15, 0.15);
                originMapView.Region = new MKCoordinateRegion(coordinates, span);

                originMapView.RemoveAnnotations();
                originMapView.AddAnnotation(new MKPointAnnotation()
                {
                    Coordinate = coordinates,
                    Title = "Your location"
                });
            }
        }

        private async void SaveBarButtonItem_Clicked(object sender, EventArgs e)
        {
            var origin = originMapView.CenterCoordinate;
            var destinarion = destinationMapView.CenterCoordinate;
            Delivery delivery = new Delivery()
            {
                Name = packageNameTextField.Text,
                Status = 0,
                OriginLatitude = origin.Latitude,
                OriginLongitude = origin.Longitude,
                DestinationLatitude = destinarion.Latitude,
                DestinationLongitude = destinarion.Longitude
            };

            await Delivery.InsertDelivery(delivery);

            UIAlertController alert = UIAlertController.Create("Success", "Added Package for delivery", UIAlertControllerStyle.Alert);

            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);
        }
    }
}