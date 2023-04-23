namespace CMSApplication.DTOs.ResponseModel
{
    public class VolunteerResponseModel : BaseResponse
    {
        public VolunteerDTO Data { get; set; }
    }

    public class VolunteersResponseModel : BaseResponse
    {
        public ICollection<VolunteerDTO> Data { get; set; } = new HashSet<VolunteerDTO>();
    }
}