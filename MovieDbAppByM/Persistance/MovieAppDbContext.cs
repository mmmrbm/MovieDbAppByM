using MovieDbAppByM.Model;
using System.Data.Entity;

namespace MovieDbAppByM.Persistance
{
    /// <summary>
    /// EF Database context for the application.
    /// </summary>
    public class MovieAppDbContext : DbContext
    {
        /// <summary>
        /// Constructs <see cref="MovieAppDbContext"/>
        /// </summary>
        public MovieAppDbContext()
            : base("name=MovieDbEntities")
        {

        }

        /// <summary>
        /// <see cref="DbSet"/> for <see cref="Movie"/>
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// <see cref="DbSet"/> for <see cref="ImdbMovie"/>
        /// </summary>
        public DbSet<ImdbMovie> ImdbMovies { get; set; }

        /// <summary>
        /// <see cref="DbSet"/> for <see cref="Actor"/>
        /// </summary>
        public DbSet<Actor> Actors { get; set; }

        /// <summary>
        /// <see cref="DbSet"/> for <see cref="Director"/>
        /// </summary>
        public DbSet<Director> Directors { get; set; }

        /// <summary>
        /// < inheritdoc />
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
