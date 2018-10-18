using MovieDbAppByM.Dto.AppDomain;
using MovieDbAppByM.Mapping;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieDbAppByM.Service
{
    public class MovieRetrieveService
    {
        #region Class Variables
        /// <summary>
        /// Reference to hold <see cref="IMovieRepository"/>
        /// </summary>
        private readonly IMovieRepository movieRepository;

        /// <summary>
        /// Reference to hold <see cref="IActorRepository"/>
        /// </summary>
        private readonly IActorRepository actorRepository;

        /// <summary>
        /// Reference to hold <see cref="IDirectorRepository"/>
        /// </summary>
        private readonly IDirectorRepository directorRepository;

        /// <summary>
        /// Reference to hold <see cref="AutoMapperConfig"/>
        /// </summary>
        private readonly AutoMapperConfig mapper;
        #endregion

        /// <summary>
        /// Constructs <see cref="MovieRetrieveService"/>
        /// </summary>
        /// <param name="movieRepository"><see cref="IMovieRepository"/> injected via Autofac.</param>
        /// <param name="actorRepository"><see cref="IActorRepository"/> injected via Autofac.</param>
        /// <param name="directorRepository"><see cref="IDirectorRepository"/> injected via Autofac.</param>
        /// <param name="movieActorRepository"><see cref="IMovieActorRepository"/> injected via Autofac.</param>
        /// <param name="movieDirectorRepository"><see cref="IMovieDirectorRepository"/> injected via Autofac.</param>
        /// <param name="mapper"><see cref="AutoMapperConfig"/> injected via Autofac.</param>
        public MovieRetrieveService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            IDirectorRepository directorRepository,
            AutoMapperConfig mapper)
        {
            this.movieRepository = movieRepository;
            this.actorRepository = actorRepository;
            this.directorRepository = directorRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Responsible to fetch information as collection of <see cref="AppMovieListItemDto"/> which
        /// required to populate the movie list in the bottom slider in the UI.
        /// </summary>
        /// <returns>The collection of <see cref="AppMovieListItemDto"/> returned from database.</returns>
        public List<AppMovieListItemDto> GetScrollViewInfo()
        {
            List<AppMovieListItemDto> scrollViewItemCollection = new List<AppMovieListItemDto>();

            foreach (var movieItem in movieRepository.GetMoviesForScrollView())
            {
                AppMovieListItemDto movieListItem = new AppMovieListItemDto(movieItem.Id, movieItem.Title, movieItem.PosterImage);
                scrollViewItemCollection.Add(movieListItem);
            }

            return scrollViewItemCollection;
        }

        /// <summary>
        /// Responsible for fetch information of a <see cref="Model.Movie"/> from database and process UI friendly manner. 
        /// </summary>
        /// <param name="movieId">Identifier of <see cref="Model.Movie"/>.</param>
        /// <returns>The information processed into <see cref="AppMovieDto"/>.</returns>
        public AppMovieDto GetSelectedMovieInfo(int movieId)
        {
            Movie selectedMovie = movieRepository.GetMovieById(movieId);
            AppMovieDto processedMovie = mapper.GetMapper().Map<AppMovieDto>(selectedMovie);
            processedMovie.Director = processedMovie.MovieDirectors.First();

            return processedMovie;
        }
    }
}
