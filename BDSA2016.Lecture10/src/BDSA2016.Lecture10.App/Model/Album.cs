namespace BDSA2016.Lecture10.App.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public string ArtistName { get; set; }
        public byte[] Cover { get; set; }
        public int? Year { get; set; }
    }
}