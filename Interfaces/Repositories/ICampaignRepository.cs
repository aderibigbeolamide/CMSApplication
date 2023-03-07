using CMSApp.Entities;

namespace CMSApp.Interfaces.Repositories
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        Task<IList<Campaign>> GetAll();
        Task<Campaign> GetCampaign(int id);
        Task<Campaign> GetCampaignByCharityHome(string Name);
        Task<Campaign> GetCampaignByDate(DateTime date);
    }
}