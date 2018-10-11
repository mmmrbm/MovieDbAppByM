using MovieDbAppByM.Core;

namespace MovieDbAppByM.Dto.AppDomain
{
    /// <summary>
    /// Dto to represent movie poster data to be sent to client side to be displayed in navigational list.
    /// </summary>
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
