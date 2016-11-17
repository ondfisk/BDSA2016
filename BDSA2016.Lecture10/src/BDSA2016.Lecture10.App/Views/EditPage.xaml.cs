using BDSA2016.Lecture10.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2016.Lecture10.App.Views
{
    public sealed partial class EditPage : Page
    {
        private AlbumViewModel _vm;

        public EditPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = e.Parameter as AlbumViewModel ?? (Application.Current as App).Container.GetService<AlbumViewModel>();
            _vm.BackCommand = new RelayCommand(o => Frame.GoBack());
            _vm.LoadArtists();

            DataContext = _vm;

            base.OnNavigatedTo(e);
        }
    }
}
