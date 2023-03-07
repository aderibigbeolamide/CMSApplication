using CMSApp.Contracts;

namespace CMSApp.Entities
{
     public class Comment : AuditableEntity // donors comments on Charities
    {
        public string Detail { get; set; }
        public int DonorId { get; set; }
        public Donor? Donor { get; set; }
        public int? CharityHomeId    { get; set; }
        public CharityHome? CharityHome { get; set; }
        public IList<Document> Documents { get; set; } = new List<Document>();
    }
}