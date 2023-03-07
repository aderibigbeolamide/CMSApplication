namespace CMSApp.DTOs.ResponseModel
{
    public class CampaignResponseModel : BaseResponse
    {
        public CampaignDTO Data { get; set; }
    }

    public class CampaignsResponseModel : BaseResponse
    {
        public ICollection<CampaignDTO> Data { get; set; } = new HashSet<CampaignDTO>();
    }
}