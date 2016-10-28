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
    [Register ("CustomRestaurantCell")]
    partial class CustomRestaurantCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView restaurantImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel restaurantName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel restaurantShortDesc { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (restaurantImage != null) {
                restaurantImage.Dispose ();
                restaurantImage = null;
            }

            if (restaurantName != null) {
                restaurantName.Dispose ();
                restaurantName = null;
            }

            if (restaurantShortDesc != null) {
                restaurantShortDesc.Dispose ();
                restaurantShortDesc = null;
            }
        }
    }
}