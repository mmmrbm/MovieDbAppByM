namespace MovieDbAppByM.Dto.AppDomain
{
    /// <summary>
    /// Dto to represent director data to be sent to client side.
    /// </summary>
    public class AppMovieDirectorDto
    {
        public string Name { get; set; }

        public byte[] ProfileImage { get; set; }
    }
}
