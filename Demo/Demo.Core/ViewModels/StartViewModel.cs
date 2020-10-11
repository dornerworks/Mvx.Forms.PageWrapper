using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Demo.Core.ViewModels
{
    public class StartViewModel : MvxViewModel
    {
        // public ICommand GoToListCommand => new MvxCommand(() =>
        // {
        //     _navigationService.Navigate<ListViewModel>();
        // });
        
        // public ICommand GoToNativeModalCommand => new MvxCommand(() =>
        // {
        //     _navigationService.Navigate<NativeModalViewModel>();
        // });
        
        public ICommand GoToFragmentStackCommand => new MvxCommand(() =>
        {
            _navigationService.Navigate<Page1FragmentViewModel>();
        });
        
        public ICommand GoToActivityStackCommand => new MvxCommand(() =>
        {
            _navigationService.Navigate<Page1ViewModel>();
        });
        
        // public ICommand GoToFormsModalCommand => new MvxCommand(() =>
        // {
        //     _navigationService.Navigate<FormsModalViewModel>();
        // });
        
        private readonly IMvxNavigationService _navigationService;

        public StartViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}