using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Assignment_2.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; } // Capitalized

        [Display(Name = "Last Name")]
        public string lastName { get; set; }  // Capitalized
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public string? Organization { get; set; } // Nullable if not required
        public virtual Category Category { get; set; } // Navigation property


        public string Slug => Regex.Replace($"{firstName} {lastName}".ToLowerInvariant(), @"[^a-z0-9]+", "-").Trim('-');

    }
}
