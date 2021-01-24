#nullable enable
using Android.OS;
using MvvmCross.Forms.Views;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Xamarin.Forms.Platform.Android;

namespace Mvx.Forms.PageWrapper.Android
{
    public abstract class MvxFormsActivity<TPage, TViewModel> : MvxActivity<TViewModel>
        where TPage : MvxContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage? _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }
        
        /// <summary>
        /// Creates the activity and maps the Xamarin.Forms page to the fragment
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(ActivityLayoutId());

            var pageFragment = Page.CreateSupportFragment(this);
            
            // register the fragment
            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.page_frame, pageFragment)
                .DisallowAddToBackStack()
                .Commit();
        }
        
        protected virtual TPage CreatePage()
        {
            return new TPage
            {
                DataContext = ViewModel
            };
        }
        
        protected virtual int ActivityLayoutId()
        {
            return Resource.Layout.xamarin_forms_container;
        }
    }
}