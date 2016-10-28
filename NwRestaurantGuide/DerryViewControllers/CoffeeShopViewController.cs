using Foundation;
using System;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    public partial class CoffeeShopViewController : BaseUITableViewController
    {
		RestaurantDataService dataService = new RestaurantDataService();

        public CoffeeShopViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var coffeeShops = dataService.GetRestaurantsForGroup(3);

			var datasource = new RestaurantDataSource(coffeeShops, this);

			TableView.Source = datasource;

			this.NavigationController.NavigationItem.Title = "Coffee Shops";
		}
    }
}