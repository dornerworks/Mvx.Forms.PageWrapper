using Demo.Core.ViewModels;
using Demo.Forms.Pages;
using Mvx.Forms.PageWrapper.iOS;

namespace Demo.iOS.Views
{
    public class Page1ViewController : MvxFormsViewController<Page1, Page1ViewModel>
    {
        public string Test { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = CreateBindingSet();
            set.Bind(this)
                .For(v => v.Test)
                .To(vm => vm.Label);
            set.Apply();
        }
    }
}