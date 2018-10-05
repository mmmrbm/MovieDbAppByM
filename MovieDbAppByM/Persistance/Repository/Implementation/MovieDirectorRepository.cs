using System;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class MovieDirectorRepository : IMovieDirectorRepository
    {
        private MovieAppDbContext movieAppDbContext = null;

        public MovieDirectorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        public MovieDirector GetMovieDirectorByMovieId(int movieId)
        {
            return movieAppDbContext.MovieDirectors.Where(movDirector => movDirector.MovieId == movieId).FirstOrDefault();
        }

        public void PersistMovieDirector(MovieDirector movieDirectorToBePersisted)
        {
            movieAppDbContext.MovieDirectors.Add(movieDirectorToBePersisted);
        }
    }
}
