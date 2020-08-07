using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Fragment = Android.Support.V4.App.Fragment;
using View = Android.Views.View;

namespace MvvmCross.Forms.PageWrapper.Android
{
    public abstract class FormsDialogFragment<TPage, TViewModel> : MvxDialogFragment<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        
        protected TPage Page;
        private Fragment _fragment;

        public FormsDialogFragment()
        {
            Page = new TPage();
        }
        
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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.xamarin_forms_fragment, null);
        }
    }
}