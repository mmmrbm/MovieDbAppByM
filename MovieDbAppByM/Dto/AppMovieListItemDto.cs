using MovieDbAppByM.Core;

namespace MovieDbAppByM.Dto
{
    public class AppMovieListItemDto : BindableBase
    {
        public AppMovieListItemDto(
            int movieId,
            byte[] moviePoster)
        {
            this.MovieId = movieId;
            this.MoviePoster = moviePoster;
        }

        public int MovieId { get; }

        public byte[] MoviePoster { get; }
    }
}
