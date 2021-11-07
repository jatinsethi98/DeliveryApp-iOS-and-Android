using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class WaitingTableViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public string userId;
        public WaitingTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliveries = new List<Delivery>();
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            deliveries = await Delivery.GetWaiting();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("waitingCell");

            var delivery = deliveries[indexPath.Row];
            cell.TextLabel.Text = delivery.Name;
            cell.DetailTextLabel.Text = $"{delivery.OriginLatitude}, {delivery.OriginLongitude}";

            return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "pickupSegue")
            {
                var selectedRow = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as PickUpViewController;
                destinationViewController.delivery = deliveries[selectedRow.Row];
                destinationViewController.userId = userId;
            }

            base.PrepareForSegue(segue, sender);
        }
    }
}