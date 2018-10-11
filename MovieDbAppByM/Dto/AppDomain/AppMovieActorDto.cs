namespace MovieDbAppByM.Dto.AppDomain
{
    /// <summary>
    /// Dto to represent actor data to be sent to client side.
    /// </summary>
    public class AppMovieActorDto
    {
        public string Name { get; set; }

        public byte[] ProfileImage { get; set; }
    }
}
