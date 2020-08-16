using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //if you dont specify this annotation, it wil create full datetime in db
        [Column(TypeName = "Date")]
        // naming formatString is important
        [DisplayFormat(DataFormatString = "{0:d}" , ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
    }
}
