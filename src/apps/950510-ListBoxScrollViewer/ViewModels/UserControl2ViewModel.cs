using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListBoxScrollViewer.Infra;

namespace ListBoxScrollViewer.ViewModels
{
    public class UserControl2ViewModel : BaseViewModel, IPageViewModel
    {
        public event EventHandler<EventArgs<string>>? ViewChanged;

        public ObservableCollection<string> MyStrings { get; }

        public string PageId { get; set; }
        public string Title { get; set; } = "View 2";

        public UserControl2ViewModel(string pageIndex = "2")
        {
            PageId = pageIndex;

            MyStrings = new ObservableCollection<string>();

            for (int i = 0; i < 15; i++)
            {
                MyStrings.Add("This is a long sample text to test a listbox scroller...");
            }
        }
    }
}
