using Foundation;
using System;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    public partial class AsianCuisineTableViewController : BaseUITableViewController
    {
		RestaurantDataService dataService = new RestaurantDataService();

        public AsianCuisineTableViewController (IntPtr handle) : base (handle)
        {
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var asianCuisine = dataService.GetRestaurantsForGroup(2);
			var datasource = new RestaurantDataSource(asianCuisine, this);

			TableView.Source = datasource;

			this.NavigationController.NavigationItem.Title = "Asian Cuisine";
		}
    }
}