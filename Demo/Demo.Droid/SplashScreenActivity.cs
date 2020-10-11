using Android.App;
using Android.Content.PM;
using MvvmCross.Forms.Platforms.Android.Views;

namespace Demo.Droid
{
    [Activity(
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : MvxFormsSplashScreenActivity<Setup, Core.App, Forms.App>
    {
        
    }
}