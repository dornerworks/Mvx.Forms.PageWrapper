using Android.App;
using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [Activity]
    public class Page2Activity : MvxFormsActivity<Page2, Page2ViewModel>
    {
        protected override bool AddToolbar()
        {
            return false;
        }
    }
}