using Android.App;
using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [Activity]
    public class Page1Activity : MvxFormsActivity<Page1, Page1ViewModel>
    {
        protected override bool AddToolbar()
        {
            return false;
        }
    }
}