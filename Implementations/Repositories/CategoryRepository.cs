using Microsoft.EntityFrameworkCore;
using CMSApp.Contexts;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> GetAll()
        {
            var categories = await _context.Categories.Where(x => x.IsDeleted == false).Include(x => x.CharityHomes).ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.Include(x => x.CharityHomes).SingleOrDefaultAsync(x => x.Id == id);
            return category;
        }

        public Category GetCategoryById(int id)
        {
            var category = _context.Categories.Include(x => x.CharityHomes).SingleOrDefault(x => x.Id == id);
            return category;
        }

        public async Task<IList<Category>> GetAllWithInfo()
        {
            var categories = await _context.Categories.Include(x => x.CharityHomes).ToListAsync();
            return categories;
        }

       
    }
}
