using DeliveryApp.Model;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace DeliveryPersonApp.iOS
{
    public partial class DeliveredTableViewController : UITableViewController
    {
        List<Delivery> deliveries;
        public string userId;
        public DeliveredTableViewController (IntPtr handle) : base (handle)
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

            deliveries = await Delivery.GetDelivered(userId);
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("delvieredCell");

            var delivery = deliveries[indexPath.Row];
            cell.TextLabel.Text = delivery.Name;
            cell.DetailTextLabel.Text = $"{delivery.DestinationLatitude}, {delivery.DestinationLatitude}";

            return cell;
        }
    }
}