using BDSA2016.Lecture11.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BDSA2016.Lecture11.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : Page
    {
        AuthViewModel _vm; 

        public SignInPage()
        {
            InitializeComponent();

            _vm = (Application.Current as App).Container.GetService<AuthViewModel>();
            _vm.BackCommand = new RelayCommand(o => Frame.Navigate(typeof(MainPage)));

            DataContext = _vm;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await _vm.Initialize();
        }
    }
}
