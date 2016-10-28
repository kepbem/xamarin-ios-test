//using Foundation;
//using System;
//using UIKit;
//using NWRestaurantGuide.Core;
//using System.CodeDom.Compiler;

//namespace NwRestaurantGuide
//{
//    partial class RestaurantTableViewController : UITableViewController
//    {
//        RestaurantDataService dataService = new RestaurantDataService();

//		public RestaurantTableViewController (IntPtr handle) : base (handle)
//		{
//		}

//		public override void ViewDidLoad()
//		{
//			base.ViewDidLoad();
//			var restaurants = dataService.GetAllRestaurants();
//			var datasource = new RestaurantDataSource(restaurants, this);

//			TableView.Source = datasource;

//			this.NavigationItem.Title = "DERRY ~ LONDONDERRY";
//		}

//		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue(segue, sender);

//			if (segue.Identifier == "RestaurantDetailSegue")
//			{
//				var restaurantDetailViewController = segue.DestinationViewController as RestaurantDetailViewController;
//				if (restaurantDetailViewController != null)
//				{
//					var source = TableView.Source as RestaurantDataSource;
//					var rowPath = TableView.IndexPathForSelectedRow;
//					var item = source.GetItem(rowPath.Row);
//					restaurantDetailViewController.SelectedRestaurant = item;
//				}

//			}
//		}
//    }
//}