using Android.OS;
using Android.Views;
using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Mvx.Forms.PageWrapper.Android;

namespace Demo.Droid.Views
{
    [MvxFragmentPresentation(
        ActivityHostViewModelType = typeof(AndroidFragmentHostViewModel),
        FragmentContentId = Resource.Id.fragment_container,
        AddToBackStack = false)]
    public class Page1Fragment : MvxFormsAppBarFragment<Page1, Page1FragmentViewModel>
    {
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            Activity.Title = Page.Title;
        }
    }
}