using Foundation;
using System.CodeDom.Compiler;
using System;
using UIKit;
using NWRestaurantGuide.Core;

namespace NwRestaurantGuide
{
    public partial class WebPage : UIViewController
    {
        public WebPage (IntPtr handle) : base (handle)
        {
        }
		//public Restaurant SelectedRestaurant
		//{
		//	get;
		//	set;
		//}

		//UIWebView webView;

		//public override void ViewDidLoad()
		//{
		//	base.ViewDidLoad();

		//	Title = "WebView";
		//	View.BackgroundColor = UIColor.White;

		//	webView = new UIWebView(View.Bounds);
		//	View.AddSubview(webView);

		//	var url = "http://www.google.com"; // NOTE: https required for iOS 9 ATS
		//	webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

		//	// if this is false, page will be 'zoomed in' to normal size
		//	webView.ScalesPageToFit = true;


		//	// iOS 9 ATS docs
		//	// http://developer.xamarin.com/guides/ios/platform_features/introduction_to_ios9/ats/
		//}

		UIWebView webView;

		private Restaurant _selectedRestaurant;

		public Restaurant SelectedRestaurant
		{
			get
			{
				return _selectedRestaurant;
			}
			set
			{
				_selectedRestaurant = value;
				updateWeb();
			}
		}

		private void updateWeb()
		{
			var url = SelectedRestaurant.Website;
			webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
		}
	}
}