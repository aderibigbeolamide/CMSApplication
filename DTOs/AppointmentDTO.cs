namespace CMSApp.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public bool IsAccomplished { get; set; }
        public bool IsApproved { get; set; }
        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public int CharityHomeId { get; set; }
        public string CharityHomeName { get; set; }
        public int Quantity { get; set; }
       
    }
}
