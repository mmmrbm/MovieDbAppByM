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
            string movieTitle,
            byte[] moviePoster)
        {
            this.MovieId = movieId;
            this.MovieTitle = movieTitle;
            this.MoviePoster = moviePoster;
        }

        public int MovieId { get; }

        public string MovieTitle { get; }

        public byte[] MoviePoster { get; }
    }
}
