using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MvvmCross.Forms.PageWrapper.Android
{
    public abstract class FormsAppCompatActivity<TPage, TViewModel> : MvxAppCompatActivity<TViewModel>
        where TPage : ContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        
        protected TPage Page;
        // protected int ContainerLayoutId = Resource.Layout.activity_fragment_container;
        public Toolbar Toolbar { get; set; }
        public AppBarLayout AppBar { get; set; }
        
        public FormsAppCompatActivity()
        {
            Page = new TPage();
        }

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
        
    }
}