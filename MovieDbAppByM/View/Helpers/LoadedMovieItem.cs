using MovieDbAppByM.Core;
using System.Windows.Media;

namespace MovieDbAppByM.View.Helpers
{
    public class LoadedMovieItem : BindableBase
    {
        private SolidColorBrush background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFBF00"));

        public LoadedMovieItem(string ImdbId)
        {
            this.ImdbId = ImdbId;
        }

        public string ImdbId { get; private set; }

        public SolidColorBrush Background
        {
            get { return this.background; }
            set { this.SetProperty(ref this.background, value); }
        }
    }
}
