using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> GetComment(int id);
        Task<IList<Comment>> GetAll();
        Task<IList<Comment>> GetCommentsByContent(string content);
        Task<IList<Comment>> GetCommentByCharityHomeId(int id);
    }
}
