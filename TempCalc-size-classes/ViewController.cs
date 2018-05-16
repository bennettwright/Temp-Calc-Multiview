using System;

using UIKit;

namespace TempCalcsizeclasses
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        
        private void compute(object sender, EventArgs args)
        {
			//check for empty textfields so no errors occur
            //when parsing
			CheckEmpty();

			double temp = Double.Parse(FahrenheitField.Text);
			double humidity = Double.Parse(HumidityField.Text);
			int windspeed = (int)WindSlider.Value;

			if (HumiditySwitch.On)
			{
				int result = (int)Math.Round(calculate.getHeatIndex(temp, humidity));
				ResultLabel.Text = String.Format("Result: {0} F", result);

				//make sure not all of them are zero (save memory)
				if (!(temp == 0 && windspeed == 0 && result == 0))
				CalculationHistoryController.AddData(String.Format("Temp: {0}, Humidity: {1}, Result: {2} F",
			        temp, humidity, result));
			}

			else
			{            
				int result = (int)Math.Round(calculate.getWindChill(temp, windspeed));
				ResultLabel.Text = String.Format("Result: {0} F", result);

				//make sure not all of them are zero (save memory)
				if(!(temp == 0 && windspeed == 0 && result == 0))
				CalculationHistoryController.AddData(String.Format("Temp: {0}, Wind speed: {1}, Result: {2} F",
		   	        temp, windspeed, result));
			}

        }

        //checks for empty textboxes so it can parse correctly
        //without throwing errors
		private void CheckEmpty()
		{
			if (FahrenheitField.Text == String.Empty)
			    FahrenheitField.Text = "0";

			if (HumidityField.Text == String.Empty)
                HumidityField.Text = "0";
		}

        partial void switchActionSheet(UISwitch sender)
        {
            string title = HumiditySwitch.On ? "Turn on Humidity?" : "Turn off Humidity";
            var controller = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            var yesAction = UIAlertAction.Create("Yes, I'm Sure!", UIAlertActionStyle.Default,
                (action) =>
                {
                    HumidityField.Enabled = HumiditySwitch.On;
				    compute(sender, null);
                });


            var noAction = UIAlertAction.Create("No way!", UIAlertActionStyle.Cancel,
                (action) =>
                {
                    HumidityField.Enabled = HumiditySwitch.On = !HumiditySwitch.On;
					compute(sender, null);
                });

            controller.AddAction(yesAction);
            controller.AddAction(noAction);
            var ppc = controller.PopoverPresentationController;
            if (ppc != null)
            {
                ppc.SourceView = sender;
                ppc.SourceRect = sender.Bounds;
            }

            PresentViewController(controller, true, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //dismiss the keyboard on background touch
            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                FahrenheitField.ResignFirstResponder();
                HumidityField.ResignFirstResponder();
            }));

            //after editing, compute 
			HumidityField.EditingDidEnd += compute;
			FahrenheitField.EditingDidEnd += compute;
			HumiditySwitch.ValueChanged += compute;

            //when slider value is changed, update UI
            WindSlider.ValueChanged += (sender, e) =>
            {
                WindSpeedLabel.Text = String.Format("Wind Speed (0-100 mph): {0}",
                                        (int)WindSlider.Value);
              
                compute(sender, e);
            };
        }

		partial void HistoryButton_TouchUpInside(UIButton sender)
		{
			UIViewController controller = Storyboard.InstantiateViewController("CalculationHistoryController");
			NavigationController.PushViewController(controller, false);
		}

		partial void AboutButton_TouchUpInside(UIButton sender)
		{
			UIViewController controller = Storyboard.InstantiateViewController("AboutController");

			NavigationController.PushViewController(controller, false);
		}
       
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
