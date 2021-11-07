using CoreLocation;
using DeliveryApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class DeliverViewController : UIViewController
    {
        public Delivery delivery;
        CLLocationManager locationManager;
        public DeliverViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliverBarButtonItem.Clicked += DeliverBarButtonItem_Clicked;
            navigationBarButtonItem.Clicked += NavigationBarButtonItem_Clicked;

            PrepareMap();
        }

        private void NavigationBarButtonItem_Clicked(object sender, EventArgs e)
        {
            var coordinates = new CLLocationCoordinate2D(delivery.DestinationLatitude, delivery.DestinationLongitude);
            var mapItem = new MKMapItem(new MKPlacemark(coordinates));
            mapItem.Name = "Pick up here";
            mapItem.OpenInMaps();
        }

        private void PrepareMap()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            deliveryMapView.ShowsUserLocation = true;

            var sapn = new MKCoordinateSpan(0.15, 0.15);
            var coordinates = new CLLocationCoordinate2D(delivery.DestinationLatitude, delivery.DestinationLongitude);

            deliveryMapView.Region = new MKCoordinateRegion(coordinates, sapn);

            deliveryMapView.AddAnnotation(new MKPointAnnotation()
            {
                Coordinate = coordinates,
                Title = "Deliver here"
            });
        }

        private async void DeliverBarButtonItem_Clicked(object sender, EventArgs e)
        {
            await Delivery.MarkAsDelivered(delivery);
        }
    }
}