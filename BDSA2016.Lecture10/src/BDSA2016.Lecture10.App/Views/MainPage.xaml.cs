using BDSA2016.Lecture10.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2016.Lecture10.App.Views
{
    public sealed partial class MainPage : Page
    {
        private readonly AlbumsViewModel _vm;

        public MainPage()
        {
            InitializeComponent();

            _vm = (Application.Current as App).Container.GetService<AlbumsViewModel>();
            _vm.AddCommand = new RelayCommand(o => Frame.Navigate(typeof(EditPage)));
            _vm.EditCommand = new RelayCommand(o => Frame.Navigate(typeof(EditPage), List.SelectedItem), o => List.SelectedItem != null);
            _vm.LoadAlbums();

            DataContext = _vm;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.EditCommand.OnCanExecuteChanged(sender);
        }
    }
}
