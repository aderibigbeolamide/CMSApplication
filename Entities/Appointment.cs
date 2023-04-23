using CMSApplication.Contracts;

namespace CMSApplication.Entities
{
      public class Appointment : AuditableEntity
    {
        public DateTime Time { get; set; }
        public bool IsApproved { get; set; }
        public int DonorId { get; set; }
        public bool IsAccomplished { get; set; }
        public int CharityHomeId { get; set; }
        public Donor Donor { get; set; }
        public CharityHome CharityHome { get; set; }
        public int Quantity { get; set; }
    }
}