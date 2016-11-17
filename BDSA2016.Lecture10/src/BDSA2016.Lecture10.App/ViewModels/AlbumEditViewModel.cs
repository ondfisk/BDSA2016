using BDSA2016.Lecture10.App.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BDSA2016.Lecture10.App.ViewModels
{
    public class AlbumEditViewModel : DisposableBaseViewModel
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;

        public ObservableCollection<ArtistViewModel> Artists { get; } = new ObservableCollection<ArtistViewModel>();

        private int _id;
        public int Id { get { return _id; } set { if (_id != value) { _id = value; OnPropertyChanged(); } } }

        private string _title;
        public string Title { get { return _title; } set { if (_title != value) { _title = value; OnPropertyChanged(); } } }

        private int? artistId;
        public int? ArtistId { get { return artistId; } set { if (artistId != value) { artistId = value; OnPropertyChanged(); } } }

        private string _artistName;
        public string ArtistName { get { return _artistName; } set { if (_artistName != value) { _artistName = value; OnPropertyChanged(); } } }

        private int? _year;
        public int? Year { get { return _year; } set { if (_year != value) { _year = value; OnPropertyChanged(); } } }

        private ImageSource _cover;
        public ImageSource Cover { get { return _cover; } set { if (_cover != value) { _cover = value; OnPropertyChanged(); } } }

        private byte[] _coverBytes;
        public byte[] CoverBytes { get { return _coverBytes; } set { if (_coverBytes != value) { _coverBytes = value; LoadImage(); OnPropertyChanged(); } } }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(async o =>
                {
                    await SaveAsync();
                    BackCommand?.Execute(this);
                }));
            }
        }

        private ICommand _pickImageCommand;
        public ICommand PickImageCommand
        {
            get
            {
                return _pickImageCommand ?? (_pickImageCommand = new RelayCommand(async o =>
                {
                    var picker = new FileOpenPicker();
                    picker.ViewMode = PickerViewMode.Thumbnail;
                    picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                    picker.FileTypeFilter.Add(".jpg");
                    picker.FileTypeFilter.Add(".jpeg");
                    picker.FileTypeFilter.Add(".png");

                    var file = await picker.PickSingleFileAsync();
                    if (file != null) // Application now has read/write access to the picked file
                    {
                        using (var stream = await file.OpenReadAsync())
                        {
                            var bytes = new byte[stream.Size];
                            using (var reader = new DataReader(stream))
                            {
                                await reader.LoadAsync((uint)stream.Size);
                                reader.ReadBytes(bytes);
                            }

                            CoverBytes = bytes;
                        }
                    }
                }));
            }
        }

        public ICommand BackCommand { get; set; }

        public AlbumEditViewModel(IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
        }

        private async Task SaveAsync()
        {
            var album = new Album
            {
                Id = Id,
                Title = Title,
                ArtistId = ArtistId,
                Year = Year,
                Cover = CoverBytes
            };
            if (Id == 0)
            {
                await _albumRepository.CreateAsync(album);
            }
            else
            {
                await _albumRepository.UpdateAsync(album);
            }
        }

        private async void LoadImage()
        {
            var image = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(CoverBytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            Cover = image;
        }

        public async void LoadArtists()
        {
            var artists = await _artistRepository.ReadAsync();
            foreach (var artist in artists.Select(
                a => new ArtistViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                }))
            {
                Artists.Add(artist);
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
                    _artistRepository.Dispose();
                    _albumRepository.Dispose();
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
