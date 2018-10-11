using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents director who directs a movie.
    /// </summary>
    [Table("Director")]
    public class Director
    {
        /// <summary>
        /// Identifier for the Director.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Director.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Profile image of the Director.
        /// </summary>
        public byte[] ProfileImage { get; set; }
    }
}
