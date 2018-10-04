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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new System.Data.Entity.Infrastructure.UnintentionalCodeFirstException();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
