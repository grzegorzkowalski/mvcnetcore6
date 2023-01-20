namespace FilmDB.Models
{
    public class GenreModel
    {
        public string Name { get; set; }
        public int GenreID { get; set; }
        public ICollection<FilmModel> Films { get; set; }
    }
}
