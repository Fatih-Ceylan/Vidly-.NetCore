using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:D}" , ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:D}" , ApplyFormatInEditMode = true)]
        public DateTime? DateAdded { get; set; }
        public byte NumberInStock { get; set; }
    }
}
