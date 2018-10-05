using MovieDbAppByM.Model;
using System.Data.Entity;

namespace MovieDbAppByM.Persistance
{
    /// <summary>
    /// EF Database context for the application.
    /// </summary>
    class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext()
            : base("name=MovieDbEntities")
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<ImdbMovie> ImdbMovies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
    }
}
