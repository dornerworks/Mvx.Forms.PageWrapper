using Android.OS;
using Android.Views;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.AppBar;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using View = Android.Views.View;

namespace MvvmCross.Forms.PageWrapper.Android
{
    public abstract class FormsAppBarFragment<TPage, TViewModel> : FormsFragment<TPage, TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        
        protected Toolbar Toolbar { get; set; }
        protected AppBarLayout AppBar { get; set; }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.xamarin_forms_app_bar_fragment, null);
        }
        
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            Toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null) Toolbar.Title = Page.Title;
        }
        
    }
}