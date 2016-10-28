using System;
using UIKit;
using NWRestaurantGuide.Core;
using System.Collections.Generic;
using Foundation;
using System.Linq;

namespace NwRestaurantGuide
{
	public class RestaurantDataSource : UITableViewSource
	{
		private List<Restaurant> restaurants;

		//string cellIdentifier = "restaurantCell"; // set in the Storyboard
		NSString cellIdentifier = new NSString("restaurantCell");

		BaseUITableViewController callingController;

		public RestaurantDataSource(List<Restaurant> restaurants, BaseUITableViewController callingController)
		{
			this.restaurants = restaurants;
			this.callingController = callingController;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return restaurants.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			var restaurant = restaurants[indexPath.Row];
			cell.TextLabel.Text = restaurant.Name;
			cell.ImageView.Image = UIImage.FromFile("Images/restaurant" + restaurant.RestaurantId + ".jpg");

			return cell;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var selectedRestaurant = restaurants[indexPath.Row];
			callingController.RestaurantSelected(selectedRestaurant);
			tableView.DeselectRow(indexPath, true);
		}

		public Restaurant GetItem(int id)
		{
			return restaurants[id];
		}
	}
}

