using Microsoft.EntityFrameworkCore;
using CMSApp.Contexts;
using CMSApp.Entities;
using CMSApp.Interfaces.Repositories;

namespace CMSApp.Implementations.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Comment>> GetAll()
        {
            var comments = await _context.Comments.Where(x => x.IsDeleted == false).Include(x => x.CharityHome).Include(x => x.Donor).Include(x => x.Documents).OrderByDescending(x => x.CreatedOn).ToListAsync();
            
            return comments;
        }

        public async Task<Comment> GetComment(int id)
        {
            var comment = await _context.Comments.Include(x => x.CharityHome).Include(x => x.Donor).Include(x => x.Documents).SingleOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<IList<Comment>> GetCommentByCharityHomeId(int id)
        {
            var comment = await _context.Comments.Where(x => x.CharityHomeId == id && x.IsDeleted == false).Include(x => x.CharityHome).Include(x => x.Donor).Include(x => x.Documents).OrderByDescending(x => x.CreatedOn).ToListAsync();
            return comment;
        }

        public async Task<IList<Comment>> GetCommentsByContent(string content)
        {
            var comment = await _context.Comments.Where(x => x.IsDeleted == false && x.Detail.ToLower().Contains(content.ToLower())).Include(x => x.CharityHome).Include(x => x.Donor).Include(x => x.Documents).ToListAsync();
            return comment;
        }
    }
}
