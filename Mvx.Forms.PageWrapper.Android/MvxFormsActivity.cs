#nullable enable
using Android.OS;
using AndroidX.AppCompat.Widget;
using Google.Android.Material.AppBar;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsActivity<TPage, TViewModel> : MvxActivity<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage _page = null!;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        protected Toolbar? Toolbar { get; set; }
        protected AppBarLayout? AppBar { get; set; }
        
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
            if (AddToolbar())
            {
                SetContentView(Resource.Layout.xamarin_forms_toolbar_activity);
                Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
                if (Toolbar?.Parent != null)
                {
                    AppBar = Toolbar?.Parent as AppBarLayout;
                    SetSupportActionBar(Toolbar);
                }
            }
            else
            {
                SetContentView(Resource.Layout.xamarin_forms_activity);
            }
            Title = Page.Title;
            
            // register the fragment
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.forms_activity_fragment_container, Page.CreateSupportFragment(this));
            transaction.Commit();
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage();
        }

        protected abstract bool AddToolbar();
    }
}