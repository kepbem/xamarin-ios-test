using Foundation;
using UIKit;
using UXDivers.Artina;
using PlotProjects.Plugin;
using PlotProjects.Plugin.Abstractions;
//using Facebook.CoreKit;
//using Google.SignIn; PMC for google login
//using Google.Core; PMC for google login

namespace NwRestaurantGuide
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate {


		// class-level declarations
		private IPlot plot;

		public override UIWindow Window
		{
			get;
			set;
		}

		// Replace here you own Facebook App Id and App Name, if you don't have one go to
		// https://developers.facebook.com/apps
		//string appId = "225155004569919";
		//string appName = "NwRestaurantGuide";

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// This is false by default,
			// If you set true, you can handle the user profile info once is logged into FB with the Profile.Notifications.ObserveDidChange notification,
			// If you set false, you need to get the user Profile info by hand with a GraphRequest
			//Profile.EnableUpdatesOnAccessTokenChange(true);
			//Settings.AppID = appId;
			//Settings.DisplayName = appName;
			//...

			// This method verifies if you have been logged into the app before, and keep you logged in after you reopen or kill your app.
			//return ApplicationDelegate.SharedInstance.FinishedLaunching(application, launchOptions);
		
			//string clientId = "268549359830-crcujg00k38qton2j1ra187ckbninodp.apps.googleusercontent.com";

			//NSError configureError;
			//Context.SharedInstance.Configure(out configureError);
			//if (configureError != null)
			//{
			//	// If something went wrong, assign the clientID manually
			//	//PMC CHANGE BELOW CALL TO 'CONSOLE' IN PRODUCTION
			//	System.Diagnostics.Debug.WriteLine("Error configuring the Google context: {0}", configureError);
			//	SignIn.SharedInstance.ClientID = clientId;
			//}


			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			//Appearance.Configure(); ADD AGAIN FOR STYLE IN FUTURE BUILD PMC

			return true;
			PlotProjects.Plugin.Plot.GetInstance(launchOptions, true);
		}
		//public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		//{
		//	//return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
		//	// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
		//	return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
	
		//}

		public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
		{
			//Important to add this:
			Plot.HandleNotification(notification);
		}

		public override void OnResignActivation(UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

