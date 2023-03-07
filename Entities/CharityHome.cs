using CMSApp.Identity;

namespace CMSApp.Entities
{
    public class CharityHome
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? LGA { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public bool IsApproved { get; set; }
        public int ApprovedBy { get; set; }
        public bool IsBan { get; set; }
        public int BannedBy { get; set; }
        public DateTime BannedOn { get; set; }
        public DateTime ApprovedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public int DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
        public IList<Document> Particulars { get; set; } = new List<Document>();
        public IList<Payment> Paymnets { get; set; } = new List<Payment>();
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public IList<Event> Events { get; set; } = new List<Event>();
        public IList<In_appMessaging> In_AppMessagings { get; set; } = new List<In_appMessaging>();
        public int UserId { get; set; }
        public User User { get; set; }
    }
}