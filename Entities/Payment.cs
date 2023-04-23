namespace CMSApplication.Entities
{
     public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int CharityHomeId { get; set; }
        public CharityHome CharityHome { get; set; }
        public int DonorId  { get; set; }
        public Donor Donor { get; set; }
        public DateTime DonationDate { get; set; }
        public string Reference { get; set; }
        public bool IsVerified { get; set; }
    }
}