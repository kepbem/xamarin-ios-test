using Foundation;
using System;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    partial class GastroPubsViewController : BaseUITableViewController
    {
		RestaurantDataService dataService = new RestaurantDataService();

        public GastroPubsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var gastroPubs = dataService.GetRestaurantsForGroup(4);

			var datasource = new RestaurantDataSource(gastroPubs, this);

			TableView.Source = datasource;

			this.NavigationController.NavigationItem.Title = "Gastro Pubs";
		}
    }
}

