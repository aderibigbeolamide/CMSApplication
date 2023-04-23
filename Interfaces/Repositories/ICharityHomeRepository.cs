using CMSApplication.DTOs;
using CMSApplication.Entities;
using System.Collections.Generic;

namespace CMSApplication.Interfaces.Repositories
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
