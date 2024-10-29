﻿using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Category { get; set; }

        public string Organization { get; set; } // No [Required] attribute
    }
}
