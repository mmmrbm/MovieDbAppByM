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
        /// <summary>
        /// Identifier for the Actor.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Actor.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Profile image of the Actor.
        /// </summary>
        public byte[] ProfileImage { get; set; }
    }
}
