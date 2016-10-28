using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;

namespace NwRestaurantGuide
{
	public partial class ViewController : UIViewController
	{
		private UIPageViewController pageViewController;
		private List<string> _pageTitles;
		private List<string> _images;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_pageTitles = new List<string> { "WELCOME", "DATA", "VOUCHERS" };
			_images = new List<string> { "Onboard-Portrait1.jpg", "Onboard-Portrait2.jpg", "Onboard-Portrait3.jpg" };

			pageViewController = this.Storyboard.InstantiateViewController("PageViewController") as UIPageViewController;
			pageViewController.DataSource = new PageViewControllerDataSource(this, _pageTitles);

			var startVC = this.ViewControllerAtIndex(0) as ContentViewController;
			var viewControllers = new UIViewController[] { startVC };

			pageViewController.SetViewControllers(viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);
			pageViewController.View.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Size.Height);
			AddChildViewController(this.pageViewController);
			View.AddSubview(this.pageViewController.View);
			pageViewController.DidMoveToParentViewController(this);

			//button.TouchUpInside += RestartTutorial;
		}


		//private void RestartTutorial(object sender, EventArgs e)
		//{
		//	var startVC = this.ViewControllerAtIndex(0) as ContentViewController;
		//	var viewControllers = new UIViewController[] { startVC };
		//	this.pageViewController.SetViewControllers(viewControllers, UIPageViewControllerNavigationDirection.Forward, false, null);
		//}

		public UIViewController ViewControllerAtIndex(int index)
		{
			var vc = this.Storyboard.InstantiateViewController("ContentViewController") as ContentViewController;
			vc.imageFile = _images.ElementAt(index);
			vc.pageIndex = index;
			return vc;
		}

		private class PageViewControllerDataSource : UIPageViewControllerDataSource
		{
			private ViewController _parentViewController;
			private List<string> _pageTitles;

			public PageViewControllerDataSource(UIViewController parentViewController, List<string> pageTitles)
			{
				_parentViewController = parentViewController as ViewController;
				_pageTitles = pageTitles;
			}

			public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
			{
				var vc = referenceViewController as ContentViewController;
				var index = vc.pageIndex;
				if (index == 0)
				{
					return null;
				}
				else {
					index--;
					return _parentViewController.ViewControllerAtIndex(index);
				}
			}

			public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
			{
				var vc = referenceViewController as ContentViewController;
				var index = vc.pageIndex;

				index++;
				if (index == _pageTitles.Count)
				{
					return null;
				}
				else {
					return _parentViewController.ViewControllerAtIndex(index);
				}
			}

			public override nint GetPresentationCount(UIPageViewController pageViewController)
			{
				return _pageTitles.Count;
			}

			public override nint GetPresentationIndex(UIPageViewController pageViewController)
			{
				return 0;
			}
		}
	}
}
