
namespace Movies.Loader.CLI.Models;

public class Movie
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public int ReleasedYear { get; set; }

    public string? MoviePath { get; set; }

    public int? MovieLength { get; set; }

    public int VoteAverage { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<GenreMovie> GenreMovies { get; set; } = new List<GenreMovie>();
}
