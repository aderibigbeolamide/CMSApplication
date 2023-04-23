using CMSApplication.Identity;

namespace CMSApplication.Entities
{
     public class Donor : BaseUser
    {
        public bool IsBan { get; set; }
        public int BannedBy { get; set; }
        public DateTime BannedOn { get; set; }
        public IList<Payment> Payments { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public int UserID { get; set; }
        public User User { get; set; }
    }
}