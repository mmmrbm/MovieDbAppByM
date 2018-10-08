using System;
using System.IO;
using System.Net;
using System.Text;

namespace MovieDbAppByM.Utility
{
    public class ImageFetchUtil
    {
        private const string imageBaseUrl = @"https://image.tmdb.org/t/p/";
        private const string crewImageUrlPath = @"w45";
        private const string thumbnailImageUrlPath = @"w92";
        private const string posterImageUrlPath = @"w500";
        private const string backdropImageUrlPath = @"w1280";

        private const string defaultImageFolder = "Images\\";
        private const string defaultActorImageName = "default-user-thumb.png";
        private const string defaultDirectorImageName = "default-user.png";
        private const string defaulPosterImageName = "empty_poster.png";
        private const string defaultBackdropImageName = "empty_backdrop.png";

        public byte[] FetchFromUrl(MovieImageTypes imageType, string imageName)
        {
            string url = string.Empty;
            byte[] imageBytes = null;

            switch (imageType)
            {
                case MovieImageTypes.Actor:
                    url = imageBaseUrl + thumbnailImageUrlPath + imageName;
                    imageBytes = GetDefaultImages(MovieImageTypes.Actor);
                    break;
                case MovieImageTypes.Director:
                    url = imageBaseUrl + thumbnailImageUrlPath + imageName;
                    imageBytes = GetDefaultImages(MovieImageTypes.Director);
                    break;
                case MovieImageTypes.Poster:
                    url = imageBaseUrl + posterImageUrlPath + imageName;
                    imageBytes = GetDefaultImages(MovieImageTypes.Poster);
                    break;
                case MovieImageTypes.Backdrop:
                    url = imageBaseUrl + backdropImageUrlPath + imageName;
                    imageBytes = GetDefaultImages(MovieImageTypes.Backdrop);
                    break;
                default:
                    break;
            }

            if (url != string.Empty && imageName != null && imageName != string.Empty)
            {
                using (var webClient = new WebClient())
                {
                    imageBytes = webClient.DownloadData(url);
                }
            }

            return imageBytes;
        }

        private byte[] GetDefaultImages(MovieImageTypes imageType)
        {
            StringBuilder pathBuilder = new StringBuilder();
            pathBuilder.Append(AppDomain.CurrentDomain.BaseDirectory);
            pathBuilder.Append(defaultImageFolder);

            switch (imageType)
            {
                case MovieImageTypes.Actor:
                    pathBuilder.Append(defaultActorImageName);
                    break;
                case MovieImageTypes.Director:
                    pathBuilder.Append(defaultDirectorImageName);
                    break;
                case MovieImageTypes.Poster:
                    pathBuilder.Append(defaulPosterImageName);
                    break;
                case MovieImageTypes.Backdrop:
                    pathBuilder.Append(defaultBackdropImageName);
                    break;
                default:
                    pathBuilder = null;
                    break;
            }

            return File.ReadAllBytes(pathBuilder.ToString());
        }
    }
}
