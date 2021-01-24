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
        AddFragment = true)]
    public class Page1Fragment : MvxFormsFragment<Page1, Page1FragmentViewModel>
    {
        public string Test { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            var set = CreateBindingSet();
            set.Bind(this).For(v => v.Test).To(vm => vm.Label).OneWay();
            set.Apply();
            return view;
        }
    }
}