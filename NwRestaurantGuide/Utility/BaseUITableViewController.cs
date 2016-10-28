using System;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
	public class BaseUITableViewController : UITableViewController
	{
		public BaseUITableViewController() : base("BaseUITableViewController", null)
		{
		}

		public BaseUITableViewController(IntPtr handle) : base(handle)
		{
		}


		public void RestaurantSelected(Restaurant selectedRestaurant)
		{
			RestaurantDetailViewController restaurantDetailViewController =
				this.Storyboard.InstantiateViewController("RestaurantDetailViewController") as RestaurantDetailViewController;
			if (restaurantDetailViewController != null)
			{
				//restaurantDetailViewController.ModalTransitionStyle = UIModalTransitionStyle.PartialCurl;
				restaurantDetailViewController.SelectedRestaurant = selectedRestaurant;

				 NavigationController.PushViewController(restaurantDetailViewController, true);
			}
		}
	}
}

