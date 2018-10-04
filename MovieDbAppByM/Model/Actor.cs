using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents actor who acts in a movie.
    /// </summary>
    [Table("Actor")]
    public class Actor
    {
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public byte[] ProfileImage { get; set; }
    }
}
