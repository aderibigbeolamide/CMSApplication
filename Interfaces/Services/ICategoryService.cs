using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<BaseResponse> AddCategory(CreateCategoryRequestModel model);
        Task<BaseResponse> UpdateCategory(UpdateCategoryRequestModel model, int id);
        Task<CategoriesResponseModel> GetAll();
        Task<CategoryResponseModel> GetById(int id);
        Task<CategoriesResponseModel> GetCategoriesByName(string name);
        Task<CategoriesResponseModel> GetAllWithInfo();
    }
}
