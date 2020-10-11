using Android.App;
using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [Activity]
    public class StartActivity : MvxFormsActivity<StartPage, StartViewModel>
    {
        protected override bool AddToolbar()
        {
            return false;
        }
    }
}