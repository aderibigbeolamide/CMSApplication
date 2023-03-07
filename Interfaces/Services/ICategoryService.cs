using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;

namespace CMSApp.Interfaces.Services
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
