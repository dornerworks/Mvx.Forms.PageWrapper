using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Demo.Core.ViewModels
{
    public class Page1FragmentViewModel : MvxViewModel
    {
        private string _label = "Xamarin.Forms Page";
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        private ICommand _nextCommand;
        public ICommand NextCommand => _nextCommand ??= new MvxCommand(() =>
        {
            _navigationService.Navigate<Page2FragmentViewModel>();
        });

        private readonly IMvxNavigationService _navigationService;

        public Page1FragmentViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}