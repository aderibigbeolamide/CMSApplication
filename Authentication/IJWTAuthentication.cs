using CMSApplication.DTOs;

namespace CMSApplication.Authentication
{
    public interface IJWTAuthentication
    {
        string GenerateToken(UserResponseModel model);
    }
}
