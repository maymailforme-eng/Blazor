namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? Gener {  get; set; }
        public string? URL { get; set; }
        public string Psoter { get; set; }
    }
}
