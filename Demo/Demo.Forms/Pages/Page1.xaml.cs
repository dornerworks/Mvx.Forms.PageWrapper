using Demo.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : MvxContentPage<Page1FragmentViewModel>
    {
        public Page1()
        {
            InitializeComponent();
        }
    }
}