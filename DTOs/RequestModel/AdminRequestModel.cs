﻿using System.ComponentModel.DataAnnotations;

namespace CMSApp.DTOs.RequestModel
{
    public class AdminRequestModel
    {

    }

    public class CreateAdminRequestModel
    {
        public string? Image { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }
     
        public bool IsSuperAdmin { get; set; }
    }

    public class UpdateAdminRequestModel
    {
        public string? Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }


    }


    
}
