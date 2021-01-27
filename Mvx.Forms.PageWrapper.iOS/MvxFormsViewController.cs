using MvvmCross.Platforms.Ios.Views;
using MvvmCross.ViewModels;
using Mvx.Forms.PageWrapper.Core;
using UIKit;
using Xamarin.Forms;

#nullable enable

namespace Mvx.Forms.PageWrapper.iOS
{
    public abstract class MvxFormsViewController<TPage, TViewModel> : MvxViewController<TViewModel>
        where TPage : MvxEmbeddedContentPage, new()
        where TViewModel : class, IMvxViewModel
    {
        private TPage? _page;
        protected TPage Page
        {
            get => _page ??= CreatePage();
            set => _page = value;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var xamarinFormsController = Page.CreateViewController();
            AddChildViewController(xamarinFormsController);
            PageContainerView().AddSubview(xamarinFormsController.View!);
            xamarinFormsController.DidMoveToParentViewController(this);
        }

        protected virtual TPage CreatePage()
        {
            return new TPage
            {
                ViewModel = ViewModel
            };
        }

        protected virtual UIView PageContainerView()
        {
            return View!;
        }
    }
}
