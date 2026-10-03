using BasicMvvm.Infra;
using System.Collections.Generic;

namespace BasicMvvm.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel? _pageViewModel;

        private readonly Dictionary<string, IPageViewModel>? _pageViewModels = new();

        private IDataModel _dataModel;

        public IDataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
            }
        }

        public IPageViewModel? CurrentPageViewModel
        {
            get
            {
                return _pageViewModel;
            }
            set
            {
                _pageViewModel = value;
                OnPropertyChanged(nameof(CurrentPageViewModel));
            }
        }


        public MainWindowViewModel(IDataModel dataModel)
        {
            _dataModel = dataModel;
            _pageViewModels["1"] = new UserControl1ViewModel("1");
            _pageViewModels["1"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                DataModel.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["2"] = new UserControl2ViewModel("2");
            _pageViewModels["2"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                DataModel.Data = "Data: " + s.Value.ToString();
            };

            _pageViewModels["3"] = new UserControl3ViewModel("3");
            _pageViewModels["3"].ViewChanged += (o, s) =>
            {
                CurrentPageViewModel = _pageViewModels[s.Value];
                DataModel.Data = "Data: " + s.Value.ToString();
            };

            CurrentPageViewModel = _pageViewModels["1"];
        }
    }
}
