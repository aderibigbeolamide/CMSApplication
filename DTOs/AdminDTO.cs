﻿namespace CMSApp.DTOs
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSuperAdmin { get; set; }

    }

}
