namespace Assignment_2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } // Navigation property
    }
}
