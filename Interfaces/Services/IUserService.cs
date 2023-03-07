using CMSApp.DTOs;

namespace CMSApp.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(UserRequestModel model);
    }
}
