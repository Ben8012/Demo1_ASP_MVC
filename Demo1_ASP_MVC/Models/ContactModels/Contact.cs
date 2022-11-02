namespace Demo1_ASP_MVC.Models.ContactModels
{
    public class Contact
    {
        public Contact(int id,string firstName, string lastName, string surName, string email, string phone, DateTime birthdate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
            Email = email;
            Phone = phone;
            Birthdate = birthdate;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Birthdate { get; set; }
        public int Follower { get; set; }
        public int Followed { get; set; }
    }
}
