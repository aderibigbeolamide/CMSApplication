using CMSApp.DTOs;
using CMSApp.Interfaces.Services;
using CMSApp.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CMSApp.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<UserResponseModel> Login(UserRequestModel model)
        {
            var user = await _userRepository.GetUser(x => x.Email == model.Email);

            if (user != null && user.Password == model.Password)
            {
                if (user.Admin != null)
                {
                    var roleA = _roleRepository.GetRolesByUserId(user.Id);
                    return new UserResponseModel
                    {
                        Id = user.Id,
                        UserName = $"{user.Admin.LastName} {user.Admin.FirstName}",
                        Email = user.Email,
                        Roles = roleA.Select(x => new RoleDTO
                        {
                            Name = x.Name,
                            Description = x.Description
                        }).ToList(),
                        Message = "Successfully logged in",
                        Success = true,
                        UserId = user.Admin.Id,
                        RoleName = "Admin",
                        Image = user.Admin.Image,
                    };
                }
                else if(user.Donor != null)
                {
                    var roleD = _roleRepository.GetRolesByUserId(user.Id);
                    return new UserResponseModel
                    {
                        Id = user.Id,
                        UserName = $"{user.Donor.LastName} {user.Donor.FirstName}",
                        Email = user.Email,
                        Roles = roleD.Select(x => new RoleDTO
                        {
                            Name = x.Name,
                            Description = x.Description
                        }).ToList(),
                        Message = "Successfully logged in",
                        Success = true,
                        UserId = user.Donor.Id,
                        RoleName = "Donor"
                    };
                }
                else if(user.CharityHome != null)
                {
                    var roleN = _roleRepository.GetRolesByUserId(user.Id);
                    return new UserResponseModel
                    {
                        Id = user.Id,
                        UserName = user.CharityHome.Name,
                        Email = user.Email,
                        Roles = roleN.Select(x => new RoleDTO
                        {
                            Name = x.Name,
                            Description = x.Description
                        }).ToList(),
                        Message = "Successfully logged in",
                        Success = true,
                        UserId = user.CharityHome.Id,
                        RoleName = "CharityHome"
                    };
                }
            }
            
            return new UserResponseModel
            {
                Message = "Invalid email or password",
                Success = false
            };
        }
    }
}
