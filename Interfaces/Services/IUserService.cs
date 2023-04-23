using CMSApplication.DTOs;

namespace CMSApplication.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(UserRequestModel model);
    }
}
