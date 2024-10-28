using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Contact
    {

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public string Category { get; set; }

        public string Organization { get; set; }
    }
}
