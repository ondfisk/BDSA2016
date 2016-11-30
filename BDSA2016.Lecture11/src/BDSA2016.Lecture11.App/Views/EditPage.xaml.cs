using BDSA2016.Lecture11.App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2016.Lecture11.App.Views
{
    public sealed partial class EditPage : Page
    {
        private AlbumEditViewModel _vm;

        public EditPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = (Application.Current as App).Container.GetService<AlbumEditViewModel>();

            var vm = e.Parameter as AlbumViewModel;
            if (vm != null)
            {
                _vm.Id = vm.Id;
                _vm.Title = vm.Title;
                _vm.ArtistId = vm.ArtistId;
                _vm.ArtistName = vm.ArtistName;
                _vm.Year = vm.Year;
                _vm.Cover = vm.Cover;
            }

            _vm.BackCommand = new RelayCommand(o => Frame.GoBack());
            _vm.LoadArtists();

            DataContext = _vm;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _vm.Dispose();

            base.OnNavigatedFrom(e);
        }
    }
}
