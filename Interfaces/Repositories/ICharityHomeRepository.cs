using CMSApp.DTOs;
using CMSApp.Entities;
using System.Collections.Generic;

namespace CMSApp.Interfaces.Repositories
{
    public interface ICharityHomeRepository : IRepository<CharityHome>
    {
        Task<IList<CharityHome>> GetAll();
        Task<CharityHome> GetCharityHome(int id);
        Task<CharityHome> GetCharityHomeByEmail(string email);
        Task<HashSet<CharityHome>> GetCharityHomeByName(string name);
        Task<HashSet<CharityHome>> GetByDescriptionContent(string content);
        Task<IList<CharityHome>> GetUnapprovedCharityHomes();
        Task<IList<CharityHome>> GetAllWithCategory();
    }
}
