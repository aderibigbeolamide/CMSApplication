﻿using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategory(int id);
        Category GetCategoryById(int id);
        Task<IList<Category>> GetAll();
        Task<IList<Category>> GetAllWithInfo();
    }
}
