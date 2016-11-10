using BDSA2016.Lecture09.MVVM.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BDSA2016.Lecture09.MVVM.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var vm = new MainPageViewModel();
            vm.GoToAlbumsPageCommand = new RelayCommand(o => Frame.Navigate(typeof(AlbumsPage)));
            vm.GoToContactsPageCommand = new RelayCommand(o => Frame.Navigate(typeof(ContactsPage)));

            DataContext = vm;
        }
    }
}
