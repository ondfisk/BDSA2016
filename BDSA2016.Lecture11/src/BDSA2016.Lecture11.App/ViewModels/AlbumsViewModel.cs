using BDSA2016.Lecture11.App.Model;
using System.Collections.ObjectModel;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using System.Windows.Input;

namespace BDSA2016.Lecture11.App.ViewModels
{
    public class AlbumsViewModel : DisposableBaseViewModel
    {
        private readonly IAlbumRepository _repository;

        public ObservableCollection<AlbumViewModel> Albums { get; } = new ObservableCollection<AlbumViewModel>();

        public RelayCommand EditCommand { get; set; }

        public ICommand AddCommand { get; set; }

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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;

                base.Dispose(disposing);
            }
        }
        #endregion
    }
}
