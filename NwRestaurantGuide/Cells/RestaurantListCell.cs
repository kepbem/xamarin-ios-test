//using System;
//using UIKit;
//using Foundation;
//using System.Drawing;

//namespace NwRestaurantGuide
//{
//	public class RestaurantListCell : UITableViewCell
//	{
//		UILabel nameLabel;
//		UILabel shortDescLabel;
//		UIImageView imageView;

//		public RestaurantListCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
//		{
//			SelectionStyle = UITableViewCellSelectionStyle.Gray;

//			ContentView.BackgroundColor = UIColor.FromRGB(254, 199, 101);

//			imageView = new UIImageView();

//			nameLabel = new UILabel()
//			{
//				Font = UIFont.FromName("Cochin-BoldItalic", 18f),
//				TextColor = UIColor.FromRGB(255, 255, 255),
//				BackgroundColor = UIColor.Clear
//			};

//			shortDescLabel = new UILabel()
//			{
//				Font = UIFont.FromName("AmericanTypewriter", 12f),
//				TextColor = UIColor.FromRGB(228, 79, 61),
//				TextAlignment = UITextAlignment.Center,
//				BackgroundColor = UIColor.Clear
//			};

//			ContentView.Add(nameLabel);
//			ContentView.Add(shortDescLabel);
//			ContentView.Add(imageView);
//		}

//		public void UpdateCell(string caption, string subtitle, UIImage image)
//		{
//			imageView.Image = image;
//			nameLabel.Text = caption;
//			shortDescLabel.Text = subtitle;
//		}

//		public override void LayoutSubviews()
//		{
//			base.LayoutSubviews();

//			imageView.Frame = new RectangleF((float)ContentView.Bounds.Width - 63, 5, 33, 33);
//			nameLabel.Frame = new RectangleF(5, 4, (float)ContentView.Bounds.Width - 63, 25);
//			shortDescLabel.Frame = new RectangleF(200, 10, 100, 20);
//		}
//	}
//}

