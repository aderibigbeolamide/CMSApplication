using CMSApplication.Contracts;

namespace CMSApplication.Entities
{
    public class Document : AuditableEntity
    {
        public string? Path { get; set; }
        public int? CharityHomeId { get; set; }
        public CharityHome? CharityHome { get; set; }
        public Comment? Comment { get; set; }
        public int? CommentId { get; set; }
    }
}