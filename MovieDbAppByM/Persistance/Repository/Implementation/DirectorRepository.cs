using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class DirectorRepository : IDirectorRepository
    {
        private MovieAppDbContext movieAppDbContext = null;

        public DirectorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        public Director GetDirectorById(int id)
        {
            return movieAppDbContext.Directors.Where(director => director.Id == id).FirstOrDefault();
        }

        public void PersistDirector(Director directorToBePersisted)
        {
            movieAppDbContext.Directors.Add(directorToBePersisted);
        }

        public bool CheckExistById(int id)
        {
            return (movieAppDbContext.Directors.Where(director => director.Id == id).FirstOrDefault() != null);
        }
    }
}
