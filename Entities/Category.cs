using CMSApp.Contracts;

namespace CMSApp.Entities
{
    public class Category : AuditableEntity //charityHome category
    {
        public string Name { get; set; }
        public IList<CharityHome> CharityHomes { get; set; } = new List<CharityHome>();
    }
}
