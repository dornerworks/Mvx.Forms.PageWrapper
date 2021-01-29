using Demo.Core.ViewModels;
using Mvx.Forms.PageWrapper;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : MvxEmbeddedContentPage<Page2FragmentViewModel>
    {
        public Page2()
        {
            InitializeComponent();
        }
    }
}