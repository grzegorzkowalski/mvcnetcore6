namespace FilmDB.Models
{
    public class ActorModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public int BirthYear { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
    }
}
