// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TempCalcsizeclasses
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AboutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FahrenheitField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HistoryButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField HumidityField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch HumiditySwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageView1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ResultLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider WindSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WindSpeedLabel { get; set; }

        [Action ("AboutButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AboutButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("HistoryButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HistoryButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("switchActionSheet:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void switchActionSheet (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutButton != null) {
                AboutButton.Dispose ();
                AboutButton = null;
            }

            if (FahrenheitField != null) {
                FahrenheitField.Dispose ();
                FahrenheitField = null;
            }

            if (HistoryButton != null) {
                HistoryButton.Dispose ();
                HistoryButton = null;
            }

            if (HumidityField != null) {
                HumidityField.Dispose ();
                HumidityField = null;
            }

            if (HumiditySwitch != null) {
                HumiditySwitch.Dispose ();
                HumiditySwitch = null;
            }

            if (ImageView1 != null) {
                ImageView1.Dispose ();
                ImageView1 = null;
            }

            if (ResultLabel != null) {
                ResultLabel.Dispose ();
                ResultLabel = null;
            }

            if (WindSlider != null) {
                WindSlider.Dispose ();
                WindSlider = null;
            }

            if (WindSpeedLabel != null) {
                WindSpeedLabel.Dispose ();
                WindSpeedLabel = null;
            }
        }
    }
}