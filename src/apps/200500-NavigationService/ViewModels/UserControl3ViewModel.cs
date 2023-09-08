using NavigationService.Infra;
using NavigationService.Services;

namespace NavigationService.ViewModels
{
    public class UserControl3ViewModel : BaseViewModel 
    {
        public string PageId { get; set; }
        public string Title { get; set; } = "View 3";

        public UserControl3ViewModel(INavigationService navigationService, string pageIndex = "3")
        {
            PageId = pageIndex;

            // Do we need both here.
            _navigationService = navigationService;
            Navigation = navigationService;

            NavigateToOne = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl1ViewModel>(); }, canExecute: o => true);
            NavigateToTwo = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl2ViewModel>(); }, canExecute: o => true);

        }

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

        public RelayCommand NavigateToOne { get; set; }
        public RelayCommand NavigateToTwo { get; set; }
        // public RelayCommand NavigateToThree { get; set; }


    }
}
