using CMSApplication.Contracts;

namespace CMSApplication.Entities
{
    public class Category : AuditableEntity //charityHome category
    {
        public string Name { get; set; }
        public IList<CharityHome> CharityHomes { get; set; } = new List<CharityHome>();
    }
}
