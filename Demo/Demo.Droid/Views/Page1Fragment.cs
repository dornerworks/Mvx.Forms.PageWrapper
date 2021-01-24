using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [MvxFragmentPresentation(
        ActivityHostViewModelType = typeof(AndroidFragmentHostViewModel),
        FragmentContentId = Resource.Id.fragment_container)]
    public class Page1Fragment : MvxFormsFragment<Page1, Page1FragmentViewModel>
    {
    }
}