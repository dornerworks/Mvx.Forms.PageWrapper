using Android.App;
using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [MvxActivityPresentation]
    [Activity]
    public class StartActivity : MvxFormsActivity<StartPage, StartViewModel>
    {
    }
}