namespace CMSApplication.Entities
{
    public class Volunteer
    {
        public int id {get;set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string phoneNumber { get; set; }
        public string voluntryName { get; set; }
        public string Documents { get; set; }
        public int CategoryId { get; set; }
        public IList<Category> Categorys { get; set; } = new List<Category>();
    }
}