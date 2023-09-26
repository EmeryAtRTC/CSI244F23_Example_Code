namespace MVCBasics.Models
{
    public class Employee
    {
        //primary key ID
        public int Id { get; set; }
        //first and last name, phone number email
        public string FirstName { get; set; }
        //prop tab
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //ctrl +shift +enter make a new line
        public bool Active { get; set; }

    }
}
