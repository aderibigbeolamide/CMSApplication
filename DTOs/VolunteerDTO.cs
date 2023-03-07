using CMSAppTOs;

namespace CMSApp.DTOs
{
    public class VolunteerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber  { get; set; }
        public string VoluntryName { get; set; }
        public string Documents { get; set; }
        public IList<CategoryDTO> Categorys { get; set; } = new List<CategoryDTO>();

    }
}