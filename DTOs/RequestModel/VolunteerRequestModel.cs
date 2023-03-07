using System.ComponentModel.DataAnnotations;

namespace CMSApp.DTOs.RequestModel
{
    public class VolunteerRequestModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string VoluntryName { get; set; }

         [Required]
        public string Documents { get; set; }
    }

    public class UpdateVolunteerRequestModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        public string VoluntryName { get; set; }
    }
}