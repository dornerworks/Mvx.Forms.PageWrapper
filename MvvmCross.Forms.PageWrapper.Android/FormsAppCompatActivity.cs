using Android.OS;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.AppBar;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MvvmCross.Forms.PageWrapper.Android
{
    public abstract class FormsAppCompatActivity<TPage, TViewModel> : MvxActivity<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        protected Toolbar Toolbar { get; set; }
        protected AppBarLayout AppBar { get; set; }
        
        protected override void OnViewModelSet()
        {
            Page.BindingContext = ViewModel;
        }

        /// <summary>
        /// Creates the activity and maps the Xamarin.Forms page to the fragment
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.xamarin_forms_activity);
            
            Title = Page.Title;
            
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar?.Parent != null)
            {
                AppBar = Toolbar?.Parent as AppBarLayout;
                SetSupportActionBar(Toolbar);
            }
            
            // register the fragment
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.forms_activity_fragment_container, Page.CreateSupportFragment(this));
            transaction.Commit();
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage();
        }
    }
}