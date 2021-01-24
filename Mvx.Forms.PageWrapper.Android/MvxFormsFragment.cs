#nullable enable
using Android.OS;
using Android.Views;
using MvvmCross.Forms.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsFragment<TPage, TViewModel> : MvxFragment<TViewModel>
        where TPage : MvxContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage? _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            var pageFragment = Page.CreateSupportFragment(Activity);
            ChildFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.page_frame, pageFragment)
                .DisallowAddToBackStack()
                .Commit();
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
                DataContext = ViewModel
            };
        }

        protected virtual int FragmentLayoutId()
        {
            return Resource.Layout.xamarin_forms_container;
        }
    }
}