using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Demo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, Core.App>
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            return base.FinishedLaunching(application, launchOptions);
        }
    }
}