using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;
using CMSApp.Entities;
using CMSApp.Interfaces.Services;
using CMSApp.Interfaces.Repositories;
using CMSAppTOs;
using CMSApp.DTOs;

namespace CMSApp.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICharityHomeRepository _charityHomeRepository;
        public CategoryService(ICategoryRepository categoryRepository, ICharityHomeRepository charityHomeRepository)
        {
            _categoryRepository = categoryRepository;
            _charityHomeRepository = charityHomeRepository;
        }
        public async Task<BaseResponse> AddCategory(CreateCategoryRequestModel model)
        {
            var check = await _categoryRepository.Get(x => x.Name == model.Name);
            if (check != null)
            {
                return new BaseResponse
                {
                    Message = "Category already existed!",
                    Success = false
                };
            }
            var category = new Category
            {
                
                Name = model.Name,
            };
            await _categoryRepository.Register(category);
            return new BaseResponse
            {
                Message = "Category added successfully!",
                Success = true
            };
        }

        public async Task<CategoriesResponseModel> GetAll()
        {
            var all = await _categoryRepository.GetAll();
            var categories = all.Where(x => x.IsDeleted == false).Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                CharityHomes = x.CharityHomes.Select(n => new CharityHomeDTO
                {
                    Name = n.Name,
                    Id = n.Id,
                    Description = n.Description,
                    CategoryName = n.Category.Name,
                    CategoryId = n.CategoryId,
                    Email = n.Email,
                    State = n.State,
                    City = n.City,
                    LGA = n.LGA
                }).ToList()
            }).ToList();
            if (categories == null)
            {
                return new CategoriesResponseModel
                {
                    Message = "Categories not available",
                    Success = false
                };
            }
            return new CategoriesResponseModel
            {
                Message = "List of categories",
                Data = categories.ToHashSet(),
                Success = true
            };
        }

        public async Task<CategoriesResponseModel> GetAllWithInfo()
        {
            var categories = await _categoryRepository.GetAllWithInfo();
            if(categories == null)
            {
                return new CategoriesResponseModel
                {
                    Message = "No category found",
                    Success = false
                };
            }
            
            var dto =  categories.Select( x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                CharityHomes = x.CharityHomes.Select(n => new CharityHomeDTO
                {
                    Name = n.Name,
                    Id = n.Id,
                    Description = n.Description,
                    CategoryName = n.Category.Name,
                    CategoryId = n.CategoryId,
                    Email = n.Email,
                    State = n.State,
                    City = n.City,
                    LGA = n.LGA
                }).ToList()
            }).ToHashSet();

            return new CategoriesResponseModel
            {
                Data = dto,
                Message = "List of Categories with information",
                Success = true
            };

        }

        public async Task<CategoryResponseModel> GetById(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return new CategoryResponseModel
                {
                    Message = "Category not found",
                    Success = false
                };
            }
            
            var categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                CharityHomes = category.CharityHomes.Select(n => new CharityHomeDTO
                {
                    Name = n.Name,
                    Id = n.Id,
                    Description = n.Description,
                    CategoryName = n.Category.Name,
                    CategoryId = n.CategoryId,
                    Email = n.Email,
                    State = n.State,
                    City = n.City,
                    LGA = n.LGA
                }).ToList()
            };
            return new CategoryResponseModel
            {
                Message = "Category found",
                Data = categoryDTO,
                Success = true
            };
        }

        public async Task<CategoriesResponseModel> GetCategoriesByName(string name)
        {
            var catg = await _categoryRepository.GetAll();
            var result = catg.Where(x => x.Name.ToLower().Contains(name.ToLower())).Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                CharityHomes = x.CharityHomes.Select(n => new CharityHomeDTO
                {
                    Name = n.Name,
                    Id = n.Id,
                    Description = n.Description,
                    CategoryName = n.Category.Name,
                    CategoryId = n.CategoryId,
                    Email = n.Email,
                    State = n.State,
                    City = n.City,
                    LGA = n.LGA
                }).ToList()
            }).ToList();
            if(result.Count == 0)
            {
                return new CategoriesResponseModel
                {
                    Message = "No category found",
                    Success = false
                };
            }
            return new CategoriesResponseModel
            {
                Data = result,
                Message = "List of categories",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateCategory(UpdateCategoryRequestModel model, int id)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Category already existed!",
                    Success = false
                };
            }
            var category = await _categoryRepository.Get(x => x.Id == id);
            if (category == null)
            {
                return new BaseResponse
                {
                    Message = "Category not found",
                    Success = false
                };
            }
            category.Name = model.Name;
            await _categoryRepository.Update(category);
            return new BaseResponse
            {
                Message = "Category updated succdessfully",
                Success = true
            };
        }
    }
}
