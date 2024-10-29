using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Contact
    {
        [Range(0,99999)]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Category { get; set; }

        public string? Organization { get; set; } // No [Required] attribute
    }
}
