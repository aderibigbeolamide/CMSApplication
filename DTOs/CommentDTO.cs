using CMSApplication.Entities;

namespace CMSApplication.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string? CharityHomeName { get; set; }
        public string DonorName { get; set; }
        public string? DonorImage { get; set; }
        public string? CharityHomeImage { get; set; }
        public int DonorId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
