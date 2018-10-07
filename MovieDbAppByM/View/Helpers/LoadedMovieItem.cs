using MovieDbAppByM.Core;
using System.Windows.Media;

namespace MovieDbAppByM.View.Helpers
{
    public class LoadedMovieItem : BindableBase
    {
        private SolidColorBrush backGround;

        public LoadedMovieItem(string ImdbId)
        {
            this.ImdbId = ImdbId;
            Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFBF00"));
        }

        public string ImdbId { get; private set; }

        public SolidColorBrush Background
        {
            get { return this.backGround; }
            set { this.SetProperty(ref this.backGround, value); }
        }
    }
}
