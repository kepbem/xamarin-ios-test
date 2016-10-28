using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NwRestaurantGuide
{
	partial class ContentViewController : UIViewController
	{
		public int pageIndex = 0;
		public string imageFile;

		public ContentViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			onBoardImage.Image = UIImage.FromBundle(imageFile);
		}
	}
}