using Demo.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : MvxContentPage<Page2FragmentViewModel>
    {
        public Page2()
        {
            InitializeComponent();
        }
    }
}