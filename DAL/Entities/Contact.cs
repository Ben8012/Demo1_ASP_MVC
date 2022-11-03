﻿namespace DAL.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? SurName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime? Birthdate { get; set; }

        public int FollowerId { get; set; }
        public int FollowedId { get; set; }
    }
}