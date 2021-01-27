using Android.App;
using Android.OS;
using Demo.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Demo.Droid.Views
{
    [Activity]
    public class FragmentHostActivity : MvxActivity<AndroidFragmentHostViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_fragment_host);
        }
    }
}