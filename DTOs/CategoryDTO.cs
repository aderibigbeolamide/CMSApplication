using CMSApp.DTOs;

namespace CMSAppTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CharityHomeDTO> CharityHomes { get; set; }
    }
}
