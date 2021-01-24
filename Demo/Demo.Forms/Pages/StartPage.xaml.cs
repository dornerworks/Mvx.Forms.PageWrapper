using Demo.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : MvxContentPage<StartViewModel>
    {
        public StartPage()
        {
            InitializeComponent();
        }
    }
}