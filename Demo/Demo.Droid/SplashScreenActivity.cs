using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace Demo.Droid
{
    [Activity(
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : MvxSplashScreenActivity<Setup, Core.App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            Xamarin.Forms.Forms.Init(this, bundle);
        }
    }
}