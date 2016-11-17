using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BDSA2016.Lecture10.App.ViewModels
{
    public class AlbumViewModel : BaseViewModel
    {
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
    }
}
