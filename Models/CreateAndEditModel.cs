namespace Assignment_2.Views.Contacts
{
    public class CreateAndEditModel
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; } // Add this property for the category
        public string Organization { get; set; }
    }
}
