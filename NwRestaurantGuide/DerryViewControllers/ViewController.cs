using System;
using System.Collections.Generic;
using System.Linq;

using NWRestaurantGuide.Shared.Helpers;
using NWRestaurantGuide.Shared.Models;
using NWRestaurantGuide.Shared.ViewModels;

using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;
using UIKit;


namespace NwRestaurantGuide
{
	public partial class ViewController : UIViewController
	{

		UIColor tintColor = UIColor.FromRGB(239, 235, 233);


		public ViewController(IntPtr handle) : base(handle)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			placeViews = new List<PlaceView>();


			NavigationController.NavigationBar.TintColor = tintColor;

			var appearance = UIBarButtonItem.AppearanceWhenContainedIn(typeof(UINavigationBar));

			appearance.SetTitleTextAttributes(new UITextAttributes
			{
				TextColor = tintColor,
				Font = UIFont.FromName("HelveticaNeue-Light", 20f)
			}, UIControlState.Normal);

			MapView.ShowsUserLocation = true;

			try
			{
				viewModel = ServiceContainer.Resolve<RestaurantFilterViewModel>();
			}
			catch
			{
				viewModel = new RestaurantFilterViewModel();
				ServiceContainer.Register<CoffeeFilterViewModel>(viewModel);
			}


			var searchButton = NavigationItem.RightBarButtonItem;
			var navigationButton = new UIBarButtonItem(UIImage.FromBundle("near"), UIBarButtonItemStyle.Plain, OpenMaps);
			NavigationItem.SetRightBarButtonItems(new[] { searchButton, navigationButton }, false);

			RefreshData(true);
		}


		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			PlaceView.ButtonAction += OnPlaceSelected;

			ScrollView.Scrolled += OnScrolled;
			ScrollView.WillEndDragging += WillEndDragging;
			ScrollView.DecelerationEnded += DecelerationEnded;
		}


		public override void ViewWillDisappear(bool animated)
		{
			PlaceView.ButtonAction -= OnPlaceSelected;

			ScrollView.Scrolled -= OnScrolled;
			ScrollView.WillEndDragging -= WillEndDragging;
			ScrollView.DecelerationEnded -= DecelerationEnded;

			base.ViewWillDisappear(animated);
		}



		void DecelerationEnded(object sender, EventArgs e)
		{
			PageControl.CurrentPage = page;
			currentPlace = viewModel.Places[page];
			SetAnnotationView(currentPlace);
		}


		void WillEndDragging(object sender, WillEndDraggingEventArgs e)
		{
			var selected = MapView?.SelectedAnnotations?.FirstOrDefault();
			if (selected != null) MapView.DeselectAnnotation(selected, true);
		}


		void OnScrolled(object sender, EventArgs e)
		{
			// Update the page when more than 50% of the previous/next page is visible
			nfloat pageWidth = ScrollView.Frame.Width;
			page = (int)NMath.Floor((ScrollView.ContentOffset.X - pageWidth / 2) / pageWidth) + 1;
		}



		partial void UpdatePlaces(UIBarButtonItem sender) => RefreshData(true);


		partial void OpenSearch(UIBarButtonItem sender)
		{
			var searchViewController = new SearchViewController();
			searchViewController.OnSearch += (searchString) => RefreshData(true, searchString);
			NavigationController.PushViewController(searchViewController, true);
		}


		void SetUpAnnotations()
		{
			var annotations = viewModel.Places.Select(p => new MKPointAnnotation
			{
				Coordinate = new CLLocationCoordinate2D(p.Geometry.Location.Latitude, p.Geometry.Location.Longitude),
				Title = p.Name
			}).ToArray();
			MapView.AddAnnotations(annotations);
			MapView.ShowAnnotations(annotations, false);
		}


		void SetAnnotationView(Place place, bool force = false)
		{
			if (force)
				SetUpAnnotations();

			var current = MapView.Annotations.FirstOrDefault(a =>
					Math.Abs(a.Coordinate.Latitude - place.Geometry.Location.Latitude) < double.Epsilon &&
						  Math.Abs(a.Coordinate.Longitude - place.Geometry.Location.Longitude) < double.Epsilon);

			if (current != null)
				MapView.SelectAnnotation(current, true);
		}


		void OpenMaps(object sender, EventArgs e)
		{
			if (viewModel.Places == null || viewModel.Places.Count == 0) return;

			viewModel.NavigateToShop(currentPlace);
		}


		async void ShowProgress(bool show)
		{
			NavigationController.NavigationBar.UserInteractionEnabled = !show;
			MapView.Hidden = show;

			if (show)
			{
				NavigationController.View.AddSubview(coffeeAnimation);
				coffeeAnimation.LoopAnimation = true;
				coffeeAnimation.ShowSadCoffee = false;
				await coffeeAnimation.StartAnimation();
			}
			else {

				if (error)
					MapView.Hidden = true;
				else {
					coffeeAnimation.LoopAnimation = false;
					coffeeAnimation.RemoveFromSuperview();
				}
			}
		}


		void ClearViews()
		{
			foreach (var placeView in placeViews) placeView.RemoveFromSuperview();

			if (MapView.Annotations != null)
				MapView.RemoveAnnotations(MapView.Annotations);
		}


		void displayRefreshDataAlert(string message)
		{
			var alertController = UIAlertController.Create(string.Empty, message, UIAlertControllerStyle.Alert);
			alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Destructive, null));
			PresentViewController(alertController, false, null);
			error = true;
		}


		async void RefreshData(bool forceRefresh = false, string search = null)
		{
			error = false;

			ShowProgress(true);
			PageControl.CurrentPage = 0;
			ClearViews();

			try
			{
				if (!viewModel.IsConnected)
				{
					displayRefreshDataAlert("no_network".LocalizedString("Network connection failure message"));
					coffeeAnimation.ShowSadCoffee = true;
					return;
				}

				await viewModel.GetLocation(forceRefresh);
				if (viewModel.Position == null)
				{
					displayRefreshDataAlert("unable_to_get_locations".LocalizedString("Places request failure message"));
					coffeeAnimation.ShowSadCoffee = true;
					return;
				}

				var items = await viewModel.GetPlaces(search);
				if (items == null || items.Count == 0)
				{
					displayRefreshDataAlert("nothing_open".LocalizedString("Places request failure if everything is already closed"));
					coffeeAnimation.ShowSadCoffee = true;
					return;
				}

				// await System.Threading.Tasks.Task.Delay(2000);

				InvokeOnMainThread(() =>
					{
						InitScrollView();
						currentPlace = viewModel.Places[0];
						SetAnnotationView(currentPlace, true);
					});

			}
			finally
			{
				ShowProgress(false);
			}
		}


		double GetFarthestDistance(double latitude, double longitude)
		{
			var farthest = viewModel.Places[viewModel.Places.Count - 1];
			var distance = farthest.GetDistance(latitude, longitude,
							   CoffeeFilter.Shared.GeolocationUtils.DistanceUnit.Kilometers);
			distance += 2; // Add two more distance units to display all map annotations properly
			return distance * MetersInKilometer;
		}


		void InitScrollView()
		{
			for (int i = 0; i < viewModel.Places.Count; i++)
			{

				var placeView = NSBundle.MainBundle.LoadNib<PlaceView>(this);

				placeView.Frame = new CGRect(ScrollView.Frame.Width * i, View.Frame.Y, ScrollView.Frame.Width, ScrollView.Frame.Height);
				placeView.PopulateWithData(viewModel.Places[i]);

				ScrollView.AddSubview(placeView);

				placeViews.Add(placeView);
			}

			ScrollView.ContentSize = new CGSize(ScrollView.Frame.Width * viewModel.Places.Count, ScrollView.Frame.Height);
			ScrollView.ScrollRectToVisible(NSBundle.MainBundle.LoadNib<PlaceView>(this).Frame, false);
		}


		async void OnPlaceSelected()
		{
			var detailsViewModel = new DetailsViewModel
			{
				Position = viewModel.Position,
				Place = currentPlace
			};

			ShowProgress(true);

			bool success = await detailsViewModel.RefreshPlace();

			if (!success)
			{
				var alertController = UIAlertController.Create(string.Empty, "unable_to_get_details".LocalizedString("Details request failure message"), UIAlertControllerStyle.Alert);
				alertController.AddAction(UIAlertAction.Create("ok".LocalizedString("OK title for button"), UIAlertActionStyle.Destructive, null));
				ShowViewController(alertController, this);
				return;
			}

			ServiceContainer.RegisterScoped<DetailsViewModel>(detailsViewModel);

			ShowViewController(Storyboard.Instantiate<PlaceDetailsViewController>(), this);

			ShowProgress(false);
		}
	}
}