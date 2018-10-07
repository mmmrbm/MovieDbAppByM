using MovieDbAppByM.Core;

namespace MovieDbAppByM.Dto
{
    public class AppMovieListItemDto : BindableBase
    {
        private int posterHeight;
        private int posterWidth;

        public AppMovieListItemDto(
            int movieId,
            byte[] moviePoster)
        {
            this.MovieId = movieId;
            this.MoviePoster = moviePoster;
            this.PosterHeight = 120;
            this.PosterWidth = 60;
        }


        public int MovieId { get; }

        public byte[] MoviePoster { get; }


        public int PosterHeight
        {
            get { return this.posterHeight; }
            set { this.SetProperty(ref this.posterHeight, value); }
        }

        public int PosterWidth
        {
            get { return this.posterWidth; }
            set { this.SetProperty(ref this.posterWidth, value); }
        }
    }
}
