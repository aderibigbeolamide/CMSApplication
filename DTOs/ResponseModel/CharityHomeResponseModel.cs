namespace CMSApplication.DTOs.ResponseModel
{
    public class CharityHomeResponseModel : BaseResponse
    {
        public CharityHomeDTO Data { get; set; }
    }

    public class CharityHomesResponseModel : BaseResponse
    {
        public IList<CharityHomeDTO> Data { get; set; } = new List<CharityHomeDTO>();
    }
}



