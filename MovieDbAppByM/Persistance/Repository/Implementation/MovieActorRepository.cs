using System.Collections.Generic;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private MovieAppDbContext movieAppDbContext = null;

        public MovieActorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        public IEnumerable<MovieActor> GetMovieActorsByMovieId(int movieId)
        {
            return movieAppDbContext.MovieActors.Where(movieActor => movieActor.MovieId == movieId);
        }

        public void PersistMovieActor(MovieActor movieActorToBePersisted)
        {
            movieAppDbContext.MovieActors.Add(movieActorToBePersisted);
        }
    }
}
