using Demo.Core.ViewModels;
using Mvx.Forms.PageWrapper;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : MvxEmbeddedContentPage<StartViewModel>
    {
        public StartPage()
        {
            InitializeComponent();
        }
    }
}