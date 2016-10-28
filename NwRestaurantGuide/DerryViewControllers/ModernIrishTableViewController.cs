using Foundation;
using System;
using UIKit;
using System.CodeDom.Compiler;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    partial class ModernIrishTableViewController : BaseUITableViewController
    {
    	RestaurantDataService dataService = new RestaurantDataService();

        public ModernIrishTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var modernIrish = dataService.GetRestaurantsForGroup(1);
			var datasource = new RestaurantDataSource(modernIrish, this);

			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 44;

			TableView.Source = datasource;

			this.NavigationController.NavigationItem.Title = "Modern Irish";
		}
    }
}




