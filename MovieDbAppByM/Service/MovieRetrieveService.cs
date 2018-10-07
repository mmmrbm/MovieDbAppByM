using MovieDbAppByM.Dto;
using MovieDbAppByM.Persistance.Repository.Contract;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MovieDbAppByM.Service
{
    public class MovieRetrieveService
    {
        private IMovieRepository movieRepository;
        private IActorRepository actorRepository;
        private IDirectorRepository directorRepository;
        private IMovieActorRepository movieActorRepository;
        private IMovieDirectorRepository movieDirectorRepository;
        private AutoMapperConfig mapper;

        public MovieRetrieveService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            IDirectorRepository directorRepository,
            IMovieActorRepository movieActorRepository,
            IMovieDirectorRepository movieDirectorRepository,
            AutoMapperConfig mapper)
        {
            this.movieRepository = movieRepository;
            this.actorRepository = actorRepository;
            this.directorRepository = directorRepository;
            this.movieActorRepository = movieActorRepository;
            this.movieDirectorRepository = movieDirectorRepository;
            this.mapper = mapper;
        }

        public ObservableCollection<AppMovieListItemDto> GetScrollViewInfo()
        {
            ObservableCollection<AppMovieListItemDto> scrollViewItemCollection = new ObservableCollection<AppMovieListItemDto>();

            foreach (var movieItem in movieRepository.GetMoviesForScrollView())
            {
                AppMovieListItemDto movieListItem = new AppMovieListItemDto(movieItem.Id, movieItem.PosterImage);
                scrollViewItemCollection.Add(movieListItem);
            }

            return scrollViewItemCollection;
        }

        public AppMovieDto GetSelectedMovieInfo(int movieId)
        {
            AppMovieDto selectedMovie = mapper.GetMapper().Map<AppMovieDto>(movieRepository.GetMovieById(movieId));

            AppMovieDirectorDto director = 
                mapper.GetMapper().Map <AppMovieDirectorDto>(
                    directorRepository.GetDirectorById((movieDirectorRepository.GetMovieDirectorByMovieId(movieId)).DirectorId));
            selectedMovie.Director = director;

            foreach (var actor in movieActorRepository.GetMovieActorsByMovieId(movieId))
            {
                AppMovieActorDto movieActor = mapper.GetMapper().Map<AppMovieActorDto>(
                    actorRepository.GetActorById(actor.ActorId));
                selectedMovie.MovieActors.Add(movieActor);
            }

            return selectedMovie;
        }
    }
}
