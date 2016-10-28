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
    [Register ("ContentViewController")]
    partial class ContentViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView onBoardImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton skipBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (onBoardImage != null) {
                onBoardImage.Dispose ();
                onBoardImage = null;
            }

            if (skipBtn != null) {
                skipBtn.Dispose ();
                skipBtn = null;
            }
        }
    }
}