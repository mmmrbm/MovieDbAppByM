﻿using System.Net;

namespace MovieDbAppByM.Service
{
    public class ImageFetchService
    {
        private const string imageBaseUrl = @"https://image.tmdb.org/t/p/";
        private const string actorImageUrlPath = @"w45";
        private const string thumbnailImageUrlPath = @"w92";
        private const string posterImageUrlPath = @"w500";
        private const string BACKDROP_IMAGE_URL_PATH = @"w1280";

        public byte[] FetchFromUrl(MovieImageTypes imageType, string imageName)
        {
            string url = string.Empty;

            switch (imageType)
            {
                case MovieImageTypes.Actor:
                    url = imageBaseUrl + actorImageUrlPath + imageName;
                    break;
                case MovieImageTypes.Thumbnail:
                    url = imageBaseUrl + thumbnailImageUrlPath + imageName;
                    break;
                case MovieImageTypes.Poster:
                    url = imageBaseUrl + posterImageUrlPath + imageName;
                    break;
                case MovieImageTypes.Backdrop:
                    url = imageBaseUrl + BACKDROP_IMAGE_URL_PATH + imageName;
                    break;
                default:
                    break;
            }

            byte[] imageBytes = null;

            if (url != string.Empty)
            {
                using (var webClient = new WebClient())
                {
                    imageBytes = webClient.DownloadData(url);
                }
                return imageBytes;
            }

            return null;
        }
    }
}
