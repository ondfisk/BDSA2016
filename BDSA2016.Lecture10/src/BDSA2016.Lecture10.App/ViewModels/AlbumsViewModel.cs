using BDSA2016.Lecture10.App.Model;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using System.Windows.Input;

namespace BDSA2016.Lecture10.App.ViewModels
{
    public class AlbumsViewModel : BaseViewModel
    {
        private readonly IAlbumRepository _repository;

        public ObservableCollection<AlbumViewModel> Albums { get; } = new ObservableCollection<AlbumViewModel>();

        public RelayCommand EditCommand { get; set; }

        public ICommand AddCommand { get; set; }

        private ICommand _resetDataCommand;
        public ICommand ResetDataCommand
        {
            get
            {
                return _resetDataCommand ?? (_resetDataCommand = new RelayCommand(async o =>
                    {
                        await _repository.SeedAsync();
                        Albums.Clear();
                        LoadAlbums();
                    }));
            }
        }

        public AlbumsViewModel(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public async void LoadAlbums()
        {
            var albums = await _repository.ReadAsync();
            foreach (var album in albums)
            {
                var a = (Application.Current as App).Container.GetService<AlbumViewModel>();
                a.Id = album.Id;
                a.Title = album.Title;
                a.ArtistId = album.ArtistId;
                a.ArtistName = album.ArtistName;
                a.CoverBytes = album.Cover;
                a.Year = album.Year;
                Albums.Add(a);
            }
        }

        public override void Dispose()
        {
            _repository.Dispose();
        }
    }
}
