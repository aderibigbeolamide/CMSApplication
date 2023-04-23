using CMSApplication.Entities;

namespace CMSApplication.DTOs
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public string DonorName { get; set; } 
        public int DonorId { get; set; }
        public double Amount { get; set; }
    }
}
