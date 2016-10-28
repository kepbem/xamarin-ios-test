using Foundation;
using System;
using System.Drawing;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    public partial class RestaurantDetailViewController : UIViewController
    {

		public RestaurantDetailViewController() : base ("RestaurantDetailViewController", null)
		{
		}
		public RestaurantDetailViewController (IntPtr handle) : base (handle)
        {
			
        }
		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		public Restaurant SelectedRestaurant
		{
			get;
			set;
		}

		public override void ViewDidLoad()
		{

			this.NavigationItem.Title = SelectedRestaurant.Name;
			base.ViewDidLoad();
			DatabindUI();
			CallButton.Enabled = true;
			//WebsiteButton.Enabled = true;

			CallButton.TouchUpInside += (object sender, EventArgs e) =>
			{

				// Create a NSUrl 
				var url = new NSUrl("tel:" + SelectedRestaurant.Telephone);

				// Use URL handler with tel: prefix to invoke Apple's Phone app, 
				// otherwise show an alert dialog                

				if (!UIApplication.SharedApplication.OpenUrl(url))
				{
					var av = new UIAlertView("Not supported",
								 "Scheme 'tel:' is not supported on this device",
								 null,
								 "OK",
								 null);
					av.Show();
				};
				this.DismissModalViewController(true);
			};


		}

		private void DatabindUI()
		{
			UIImage img = UIImage.FromFile("Images/" + SelectedRestaurant.ImagePath + ".jpg");
			RestaurantImageView.Image = img;
			NameLabel.Text = SelectedRestaurant.Name;
			ShortDescriptionText.Text = SelectedRestaurant.Description;
		}

    }
}