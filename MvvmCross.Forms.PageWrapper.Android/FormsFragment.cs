using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

namespace MvvmCross.Forms.PageWrapper.Android
{
    public abstract class FormsFragment<TPage, TViewModel> : MvxFragment<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        
        protected TPage Page;
        private Fragment _fragment;

        public FormsFragment()
        {
            Page = new TPage();
        }
        
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
    }
}