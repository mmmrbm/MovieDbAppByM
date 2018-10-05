using AutoMapper;
using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance;
using System.Linq;

namespace MovieDbAppByM.Service
{
    public class MoviePersistanceService
    {
        MovieInfoFetchService movieInfoFetchService = null;

        IMapper mapper = null;

        public MoviePersistanceService()
        {
            movieInfoFetchService = new MovieInfoFetchService();
            mapper = AutoMapperConfig.GetMapper();
        }

        public void PersistMoive()
        {
            MovieAppDbContext dbContext = new MovieAppDbContext();

            string movieId = "tt0133093";

            TmdbMovieInformatonDto movieFromApi = movieInfoFetchService.GetMovieAsync(movieId);
            TmdbMovieCastInfoDto movieCastFromApi = movieInfoFetchService.GetMovieCreditsAsync(movieId);

            Movie movie = mapper.Map<Movie>(movieFromApi);
            dbContext.Movies.Add(movie);

            foreach (var castedActor in movieCastFromApi.Cast.Take(6))
            {
                Actor actor = mapper.Map<Actor>(castedActor);
                dbContext.Actors.Add(actor);

                MovieActor movieActor = new MovieActor()
                {
                    MovieId = movieCastFromApi.Id,
                    ActorId = castedActor.Id,
                    CastOrder = castedActor.Order
                };
                dbContext.MovieActors.Add(movieActor);
            }

            TmdbCrewDto directorDtoFromApi = movieCastFromApi.Crew
                .Where(crew => crew.Job == "Director")
                .FirstOrDefault();

            Director director = mapper.Map<Director>(directorDtoFromApi);
            dbContext.Directors.Add(director);

            MovieDirector movieDirector = new MovieDirector()
            {
                MovieId = movieCastFromApi.Id,
                DirectorId = directorDtoFromApi.Id
            };
            dbContext.MovieDirectors.Add(movieDirector);

            dbContext.SaveChanges();
        }
    }
}
