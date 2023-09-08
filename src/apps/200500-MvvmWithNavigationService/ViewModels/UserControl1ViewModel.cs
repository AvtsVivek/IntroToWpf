using MvvmWithNavigationService.Infra;
using MvvmWithNavigationService.Services;

namespace MvvmWithNavigationService.ViewModels
{
    public class UserControl1ViewModel : BaseViewModel 
    {
        public string PageId { get; set; }
        public string Title { get; set; }

        private INavigationService _navigationService;

        public INavigationService Navigation
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        // public RelayCommand NavigateToOne { get; set; }
        public RelayCommand NavigateToTwo { get; set; }
        public RelayCommand NavigateToThree { get; set; }



        public UserControl1ViewModel(INavigationService navigationService, string pageIndex = "1")
        {
            PageId = pageIndex;
            Title = "View 1";

            // Do we need both here.
            _navigationService = navigationService;
            Navigation = navigationService;

            // NavigateToOne = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl1ViewModel>(); }, canExecute: o => true);
            NavigateToTwo = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl2ViewModel>(); }, canExecute: o => true);
            NavigateToThree = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl3ViewModel>(); }, canExecute: o => true);

        }
    }
}
