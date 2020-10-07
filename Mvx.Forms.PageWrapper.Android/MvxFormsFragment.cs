using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsFragment<TPage, TViewModel> : MvxFragment<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        
        private Fragment _fragment;
        
        public override void OnViewModelSet()
        {
            Page.BindingContext = ViewModel;
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.xamarin_forms_fragment, null);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            if (_fragment != null) return; // recreating the fragment will cause an empty fragment.
            _fragment = Page.CreateSupportFragment(Activity);
            ChildFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.forms_fragment_container, _fragment)
                .Commit();
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage();
        }
    }
}