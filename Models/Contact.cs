namespace Assignment_2.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string firstName { get; set; } // Capitalized
        public string lastName { get; set; }  // Capitalized
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public string? Organization { get; set; } // Nullable if not required
        public virtual Category Category { get; set; } // Navigation property
    }
}
