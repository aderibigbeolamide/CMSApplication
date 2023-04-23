using System.ComponentModel.DataAnnotations;

namespace CMSApplication.DTOs.RequestModel
{
    public class CategoryRequestModel
    {
       
    }
    public class CreateCategoryRequestModel
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string Name { get; set; }
    }

    public class UpdateCategoryRequestModel
    {
        public string Name { get; set; }
    }
}
