namespace Movies.Loader.CLI.Models;

public class GenreMovie
{
    public Guid MovieId { get; set; }

    public virtual Movie Movie { get; set; }

    public Guid GenreId { get; set; }

    public virtual Genre Genre { get; set; }
}
