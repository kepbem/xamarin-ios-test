using Foundation;
using System;
using UIKit;

namespace NwRestaurantGuide
{
    public partial class VoucherViewController : UIViewController
    {
        public VoucherViewController (IntPtr handle) : base (handle)
        {
        }
		UIWebView voucherWebView;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "WebView";
			View.BackgroundColor = UIColor.White;

			voucherWebView = new UIWebView(View.Bounds);
			View.AddSubview(voucherWebView);

			var url = "http://www.creativedevelopmentni.com/testvoucher/"; // NOTE: https required for iOS 9 ATS
			voucherWebView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

			// if this is false, page will be 'zoomed in' to normal size
			voucherWebView.ScalesPageToFit = true;


			// iOS 9 ATS docs
			// http://developer.xamarin.com/guides/ios/platform_features/introduction_to_ios9/ats/
		}
    }
}