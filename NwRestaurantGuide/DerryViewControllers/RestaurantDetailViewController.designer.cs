// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NwRestaurantGuide
{
    [Register ("RestaurantDetailViewController")]
    partial class RestaurantDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CallButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RestaurantImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView ShortDescriptionText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton WebsiteButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CallButton != null) {
                CallButton.Dispose ();
                CallButton = null;
            }

            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (RestaurantImageView != null) {
                RestaurantImageView.Dispose ();
                RestaurantImageView = null;
            }

            if (ShortDescriptionText != null) {
                ShortDescriptionText.Dispose ();
                ShortDescriptionText = null;
            }

            if (WebsiteButton != null) {
                WebsiteButton.Dispose ();
                WebsiteButton = null;
            }
        }
    }
}