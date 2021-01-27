#nullable enable
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using Mvx.Forms.PageWrapper.Core;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsDialogFragment<TPage, TViewModel> : MvxDialogFragment<TViewModel>
        where TPage : MvxEmbeddedContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage? _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var pageFragment = Page.CreateSupportFragment(Activity);
            ChildFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.page_frame, pageFragment)
                .DisallowAddToBackStack()
                .Commit();

            return base.OnCreateDialog(savedInstanceState);
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(FragmentLayoutId(), container, false);
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage
            {
                ViewModel = ViewModel
            };
        }
        
        protected virtual int FragmentLayoutId()
        {
            return Resource.Layout.xamarin_forms_container;
        }
    }
}