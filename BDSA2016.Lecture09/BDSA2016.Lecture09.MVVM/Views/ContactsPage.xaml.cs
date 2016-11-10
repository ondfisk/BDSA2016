using BDSA2016.Lecture09.MVVM.ViewModels;
using Windows.UI.Xaml.Controls;

namespace BDSA2016.Lecture09.MVVM.Views
{
    public sealed partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            InitializeComponent();

            var vm = new ContactsPageViewModel();
            vm.BackCommand = new RelayCommand(o => Frame.Navigate(typeof(MainPage)));
            vm.NewCommand = new RelayCommand(o => Frame.Navigate(typeof(CreateContactPage)));
            vm.Initialize();

            DataContext = vm;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(CreateContactPage));
        }
    }
}
