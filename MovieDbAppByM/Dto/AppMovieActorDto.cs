namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent actor data to be sent to client side.
    /// </summary>
    public class AppMovieActorDto
    {
        public string ActorName { get; set; }

        public byte[] ActorImage { get; set; }

        public int CastOrder { get; set; }
    }
}
