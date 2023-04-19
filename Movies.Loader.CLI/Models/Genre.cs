
namespace Movies.Loader.CLI.Models;

public class Genre
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<GenreMovie> GenreMovies { get; set; } = new List<GenreMovie>();
}
