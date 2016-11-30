namespace BDSA2016.Lecture11.App.ViewModels
{
    public class ArtistViewModel : BaseViewModel
    {
        private int _id;
        public int Id { get { return _id; } set { if (_id != value) { _id = value; OnPropertyChanged(); } } }

        private string _name;
        public string Name { get { return _name; } set { if (_name != value) { _name = value; OnPropertyChanged(); } } }
    }
}