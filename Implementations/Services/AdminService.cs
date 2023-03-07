using CMSApp.DTOs;
using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;
using CMSApp.Entities;
using CMSApp.Identity;
using CMSApp.Interfaces.Services;
using CMSApp.Interfaces.Repositories;
using CMSApp.Email;

namespace CMSApp.Implementations.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICharityHomeRepository _charityHomeRepository;
        private readonly IEmailSender _email;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository, IDonorRepository donorRepository, ICharityHomeRepository charityHomeRepository, IAppointmentRepository appointmentRepository, IEmailSender email)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _donorRepository = donorRepository;
            _charityHomeRepository = charityHomeRepository;
            _appointmentRepository = appointmentRepository;
            _email = email;
        }

        public async Task<AdminsResponseModel> GetAll()
        {
            var admins = await _adminRepository.GetAllAdmins();
            if (admins == null)
            {
                return new AdminsResponseModel
                {
                    Message = "No administrator found",
                    Success = false
                };
            }
            return new AdminsResponseModel
            {
                Message = "List of administrators",
                Data = admins.Select(x => new AdminDTO
                {
                    Id = x.Id,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IsSuperAdmin = x.IsSuperAdmin,
                    PhoneNumber = x.PhoneNumber,
                    Image = x.Image
                }).ToHashSet(),
                Success = true
            };
        }

        public async Task<AdminResponseModel> GetById(int id)
        {
            var admin = await _adminRepository.GetAdminInfo(id);
            if (admin == null || admin.IsDeleted == true)
            {
                return new AdminResponseModel
                {
                    Message = "Admin not found",
                    Success = false,
                };
            }
            return new AdminResponseModel
            {
                Data = new AdminDTO
                {
                    Password = admin.Password,
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    PhoneNumber = admin.PhoneNumber,
                    IsSuperAdmin = admin.IsSuperAdmin,
                    Id = admin.Id,
                    Image = admin.Image
                },
                Success = true,
                Message = "",
            };
        }

        public async Task<BaseResponse> AddAdmin(AddAdminRequestModel add)
        {
            var check = await _userRepository.Get(x => x.Email == add.Email);
            if(check != null)
            {
                return new BaseResponse
                {
                    Message = "A user with this email already Existed",
                    Success = false,
                };
            }

            var user = new User
            {
                Email = add.Email,
                UserName = add.Email,
                Password = add.Email,
            };

            var addUser = await _userRepository.Register(user);

            var mail = new EmailRequestModel
            {
                ReceiverEmail = add.Email,
                ReceiverName = add.Email,
                Message = $"You have been registered successfully as an Administrator on CMSApp-CMS.\nClick this link\n file:///C:/Users/user/Desktop/CMSAppFrontEnd/AdminRegistration/index.html \nto complete your registration\nIf you are unable to click the link, kindly copy and paste the link to your browser.",
                Subject = "CMSApp-CMS Registration",
            };
            await _email.SendEmail(mail);
            return new BaseResponse
            {
                Message = $"Email sent to {add.Email} successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> RegisterAdmin(CreateAdminRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Information cannot be empty!",
                    Success = false
                };
            }
            var  checkAdmin = await _adminRepository.Get(x => x.Email == model.Email);
            if(checkAdmin != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Success = false,
                };
            }
            var check = await _userRepository.Get(x => x.Email == model.Email);
            if (check != null)
            {
                return new BaseResponse
                {
                    Message = "Email already exist",
                    Success = false,
                };
            }

            var user = new User
            {
                Email = model.Email,
                UserName = $"{model.LastName} {model.FirstName}",
                Password = model.Password,
            };

            var addUser = await _userRepository.Register(user);

            // if(check.RoleName.ToLower() == "admin")
            // {
            //     model.IsSuperAdmin = false;
            // }
            // else if(check.RoleName.ToLower() == "superadmin")
            // {
            //     model.IsSuperAdmin = true;
            // }
            
            if(model.IsSuperAdmin == true)
            {
                var roleA = await _roleRepository.Get(x => x.Name.ToLower() == "superadmin");
                if (roleA == null)
                {
                    return new BaseResponse
                    {
                        Message = "Role not found",
                        Success = false
                    };
                }

                var userRoleA = new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleA.Id
                };

                user.UserRoles.Add(userRoleA);
                var updateUserA = await _userRepository.Update(user);
            }
            else if(model.IsSuperAdmin == false)
            {
                var role = await _roleRepository.Get(x => x.Name.ToLower() == "admin");
                if (role == null)
                {
                    return new BaseResponse
                    {
                        Message = "Role not found",
                        Success = false
                    };
                }

                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id
                };

                user.UserRoles.Add(userRole);
                var updateUserB = await _userRepository.Update(user);
            }

            var admin = new Admin
            {
                
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                IsSuperAdmin = model.IsSuperAdmin,
                UserID = user.Id,
                Image = model.Image,
                
            };
            
            var addadmin = await _adminRepository.Register(admin);

            admin.CreatedBy = addadmin.Id;
            admin.LastModifiedBy = addadmin.Id;
            admin.IsDeleted = false;

           

            await _adminRepository.Update(admin);

            var mail = new EmailRequestModel
            {
                ReceiverEmail = admin.Email,
                ReceiverName = $"{admin.LastName} {admin.FirstName}",
                Message = $"Dear {admin.LastName.ToUpper()} {admin.FirstName}; you have been registered successfully as an Administrator on CMSApp-CMS",
                Subject = "CMSApp-CMS Registration",
            };

            await _email.SendEmail(mail);
            return new BaseResponse
            {
                Success = true,
                Message = "Admin added successfully!"
            };
        }

        public async Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Information cannot be empty",
                    Success = false
                };
            }
            var admin = await _adminRepository.Get(x => x.Id == id);
            if (admin == null)
            {
                return new BaseResponse
                {
                    Message = "Admin not found",
                    Success = false
                };
            }
            //var folderPath = Path.Combine(Directory.GetCurrentDirectory() + "\\Images\\");
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //var fileName = Path.GetFileNameWithoutExtension(model.Image.FileName);
            //var filePath = Path.Combine(folderPath, model.Image.FileName);
            //var extension = Path.GetExtension(model.Image.FileName);
            //if (!Directory.Exists(filePath))
            //{
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await model.Image.CopyToAsync(stream);
            //    }
            //    admin.Image = fileName;
            //}
            admin.LastModifiedBy = admin.Id;
            await _adminRepository.Update(admin);

            return new BaseResponse
            {
                Message = "Admin information updated successfully.",
                Success = true
            };


        }
    }
}
