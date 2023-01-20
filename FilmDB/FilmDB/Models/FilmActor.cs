namespace FilmDB.Models
{
    public class FilmActor
    {
        public int FilmModelID { get; set; }
        public FilmModel Film { get; set; }
        public int ActorModelID { get; set; }
        public ActorModel Actor { get; set; }
    }
}
