using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class DeliveringTableViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public string userId;
        public DeliveringTableViewController (IntPtr handle) : base (handle)
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

            deliveries = await Delivery.GetBeingDelivered(userId);
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("deliveringCell");

            var delivery = deliveries[indexPath.Row];
            cell.TextLabel.Text = delivery.Name;
            cell.DetailTextLabel.Text = $"{delivery.DestinationLatitude}, {delivery.DestinationLongitude}";

            return cell;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if(segue.Identifier == "deliverSegue")
            {
                var selectedRow = TableView.IndexPathForSelectedRow;
                var destinationViewController = segue.DestinationViewController as DeliverViewController;
                destinationViewController.delivery = deliveries[selectedRow.Row];
            }

            base.PrepareForSegue(segue, sender);
        }
    }
}