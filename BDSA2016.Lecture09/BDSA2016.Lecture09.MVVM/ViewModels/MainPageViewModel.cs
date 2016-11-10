using System.Windows.Input;

namespace BDSA2016.Lecture09.MVVM.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand GoToAlbumsPageCommand { get; set; }
        public ICommand GoToContactsPageCommand { get; set; }
    }
}
