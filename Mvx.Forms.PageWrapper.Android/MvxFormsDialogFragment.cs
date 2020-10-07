using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Fragment = AndroidX.Fragment.App.Fragment;
using View = Android.Views.View;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsDialogFragment<TPage, TViewModel> : MvxDialogFragment<TViewModel>
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
        
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            if (_fragment == null)
            {
                _fragment = Page.CreateSupportFragment(Activity);
                ChildFragmentManager
                    .BeginTransaction()
                    .Replace(Resource.Id.forms_fragment_container, _fragment)
                    .Commit();
            }

            return base.OnCreateDialog(savedInstanceState);
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.xamarin_forms_fragment, null);
        }
    }
}