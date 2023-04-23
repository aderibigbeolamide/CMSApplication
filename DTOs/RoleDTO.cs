using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.DTOs
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
    public class RoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class RoleResponseodel : BaseResponse
    {
        public RoleDTO Data { get; set; }
    }
    public class RolesResponseodel : BaseResponse
    {
        public ICollection<RoleDTO> Data { get; set; } = new HashSet<RoleDTO>();
    }
}
