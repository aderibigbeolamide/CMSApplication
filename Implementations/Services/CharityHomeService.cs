using CMSApp.DTOs;
using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;
using CMSApp.Entities;
using CMSApp.Email;
using CMSApp.Interfaces.Services;
using CMSApp.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using CMSApp.Identity;

namespace CMSApp.Implementations.Services
{
    public class CharityHomeService : ICharityHomeService
    {
        private readonly ICharityHomeRepository _charityHomeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IEmailSender _email;

        public CharityHomeService(ICharityHomeRepository charityHomeRepository, ICategoryRepository categoryRepository, IUserRepository userRepository, IRoleRepository roleRepository, IDocumentRepository documentRepository, IEmailSender email)
        {
            _charityHomeRepository = charityHomeRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _documentRepository = documentRepository;
            _email = email;
        }

        public async Task<BaseResponse> ApproveCharityHome(int id)
        {
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if(charityHome == null)
            {
                return new BaseResponse
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            charityHome.IsApproved = true;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "CharityHome approved successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> BanCharityHome(int id)
        {
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if (charityHome == null)
            {
                return new BaseResponse
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            charityHome.IsBan = true;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "CharityHome banned successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> UnbanCharityHome(int id)
        {
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if (charityHome == null)
            {
                return new BaseResponse
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            charityHome.IsBan = false;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "CharityHome unbanned successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> DeleteCharityHome(int id)
        {
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if (charityHome == null)
            {
                return new BaseResponse
                {
                    Message = "NGO not found",
                    Success = false
                };
            }
            charityHome.IsDeleted = true;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "Account deleted successfully",
                Success = true
            };
        }

        public async Task<CharityHomesResponseModel> GetAll()
        {
            var charityHomes = await _charityHomeRepository.GetAll();
            if (charityHomes == null)
            {
                return new CharityHomesResponseModel
                {
                    Message = "No category found",
                    Success = false
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var dtos = charityHomes.Select(x => new CharityHomeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                State = x.State,
                City = x.City,
                LGA = x.LGA,
                Address = x.Address,
                Id = x.Id,
                Image = x.Image,
                Description = x.Description,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                AccountName = x.AccountName,
                AccountNumber = x.AccountNumber,
                BankName = x.BankName,
                IsApproved = x.IsApproved,
                IsBanned = x.IsBan,
                IsDeleted = x.IsDeleted,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                
            }).ToList();
            return new CharityHomesResponseModel
            {
                Success = true,
                Data = dtos,
                Message = "List of NGOs",
            };
        }

        public async Task<int> GetAllCount()
        {
            var charityHomes = await GetAll();
            var count = charityHomes.Data.Count;
            return count;
        }

        public async Task<CharityHomesResponseModel> GetAllWithCategory()
        {
            var charityHomes = await _charityHomeRepository.GetAllWithCategory();
            if(charityHomes == null)
            {
                return new CharityHomesResponseModel
                {
                    
                    Message = "CharityHomes not found",
                    Success = false
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            return new CharityHomesResponseModel
            {
                Data = charityHomes.Select(x => new CharityHomeDTO
                {
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                    State = x.State,
                    City = x.City,
                    LGA = x.LGA,
                    Address = x.Address,
                    Id = x.Id,
                    Description = x.Description,
                    Image = x.Image,
                    Particulars = doc.Select(a => new DocumentDTO
                    {
                        Name = a.Name
                    }).ToList(),
                    AccountName = x.AccountName,
                    AccountNumber = x.AccountNumber,
                    BankName = x.BankName,
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId,
                    IsApproved = x.IsApproved,
                    IsBanned = x.IsBan,
                    IsDeleted = x.IsDeleted,
                }).ToList(),
                Message = "List of CharityHomes",
                Success = true
            };
        }

        public async Task<CharityHomesResponseModel> GetByDescriptionContent(string content)
        {
            var charityHomes = await _charityHomeRepository.GetByDescriptionContent(content);
            if (charityHomes == null)
            {
                return new CharityHomesResponseModel
                {
                    Message = "No CharityHome found",
                    Success = false
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var dtos = charityHomes.Select( x => new CharityHomeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                State = x.State,
                City = x.City,
                LGA = x.LGA,
                Address = x.Address,
                Id = x.Id,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                Image = x.Image,
                
                AccountName = x.AccountName,
                AccountNumber = x.AccountNumber,
                BankName = x.BankName,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                Description = x.Description,
                IsApproved = x.IsApproved,
                IsBanned = x.IsBan,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return new CharityHomesResponseModel
            {
                Success = true,
                Data = dtos,
                Message = "List of NGOs",
            };
        }

        public async Task<CharityHomeResponseModel> GetCharityHome(int id)
        {
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if(charityHome == null)
            {
                return new CharityHomeResponseModel
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            var doc = await _documentRepository.GetDocumentsByCharityHomeId(charityHome.Id);
            var dto = new CharityHomeDTO
            {
                Name = charityHome.Name,
                Email = charityHome.Email,
                Password = charityHome.Password,
                State = charityHome.State,
                City = charityHome.City,
                LGA = charityHome.LGA,
                Address = charityHome.Address,
                Id = charityHome.Id,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                Image = charityHome.Image,
                AccountName = charityHome.AccountName,
                AccountNumber = charityHome.AccountNumber,
                BankName = charityHome.BankName,
                IsApproved = charityHome.IsApproved,
                IsBanned = charityHome.IsBan,
                IsDeleted = charityHome.IsDeleted,
                CategoryName = charityHome.Category.Name,
                CategoryId = charityHome.CategoryId,
                Description = charityHome.Description,
            };
            return new CharityHomeResponseModel
            {
                Message = "",
                Success = true,
                Data = dto
            };
        }

        public async Task<CharityHomeResponseModel> GetCharityHomeByEmail(string email)
        {
            var charityHome = await _charityHomeRepository.GetCharityHomeByEmail(email);
            if(charityHome == null)
            {
                return new CharityHomeResponseModel
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var dto = new CharityHomeDTO
            {
                Name = charityHome.Name,
                Email = charityHome.Email,
                Password = charityHome.Password,
                State = charityHome.State,
                City = charityHome.City,
                LGA = charityHome.LGA,
                Address = charityHome.Address,
                Id = charityHome.Id,
                Image = charityHome.Image,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                AccountName = charityHome.AccountName,
                AccountNumber = charityHome.AccountNumber,
                BankName = charityHome.BankName,
                IsApproved = charityHome.IsApproved,
                IsBanned = charityHome.IsBan,
                IsDeleted = charityHome.IsDeleted,
                CategoryName = charityHome.Category.Name,
                CategoryId = charityHome.CategoryId,
                Description = charityHome.Description,
            };
            return new CharityHomeResponseModel
            {
                Success = true,
                Data = dto,
                Message = ""
            };
        }

        public async Task<CharityHomesResponseModel> GetCharityHomeByName(string name)
        {
            var charityHomes = await _charityHomeRepository.GetCharityHomeByName(name);
            if(charityHomes == null)
            {
                return new CharityHomesResponseModel
                {
                    Success = false,
                    Message = "No CharityHome found"
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var dtos = charityHomes.Select(  x => new CharityHomeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                State = x.State,
                City = x.City,
                LGA = x.LGA,
                Address = x.Address,
                Id = x.Id,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                Image = x.Image,
                AccountName = x.AccountName,
                AccountNumber = x.AccountNumber,
                BankName = x.BankName,
                IsApproved = x.IsApproved,
                IsBanned = x.IsBan,
                IsDeleted = x.IsDeleted,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                Description = x.Description,
            }).ToList();
            return  new CharityHomesResponseModel
            {
                Success = true,
                Data = dtos,
                Message = "List of CharityHomes",
            };
        }

        public async Task<CharityHomesResponseModel> GetUnapprovedCharityHomes()
        {
            var charityHomes = await _charityHomeRepository.GetUnapprovedCharityHomes();
            if (charityHomes == null)
            {
                return new CharityHomesResponseModel
                {
                    Message = "No CharityHome found",
                    Success = false,
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var dtos = charityHomes.Select(x => new CharityHomeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                State = x.State,
                City = x.City,
                LGA = x.LGA,
                Address = x.Address,
                Id = x.Id,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                Image = x.Image,
                AccountName = x.AccountName,
                AccountNumber = x.AccountNumber,
                BankName = x.BankName,
                IsApproved = x.IsApproved,
                IsBanned = x.IsBan,
                IsDeleted = x.IsDeleted,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                Description = x.Description,
            }).ToList();
            return new CharityHomesResponseModel
            {
                Success = true,
                Data = dtos,
                Message = "List Of Unapproved CharityHomes",
            };
        }

        public async Task<int> GetUnapprovedCharityHomesCount()
        {
            var charityHome = await GetUnapprovedCharityHomes();
            var count = charityHome.Data.Count;
            return count;
        }

        public async Task<BaseResponse> Register(CreateCharityHomeRequestModel model)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "Information cannot ne empty",
                    Success = false
                };
            }
            var check = await _userRepository.Get(x => x.Email == model.Email);
            if (check != null)
            {
                return new BaseResponse
                {
                    Message = "E-mail already existed",
                    Success = false
                };
            }

            var role = await _roleRepository.Get(x => x.Name.ToLower() == "charityHome");
            if (role == null)
            {
                return new BaseResponse
                {
                    Message = "Role not found",
                    Success = false
                };
            }

            var category = await _categoryRepository.Get(x => x.Name == model.CategoryName);
            if (category == null)
            {
                return new BaseResponse
                {
                    Message = "Category not available",
                    Success = false
                };
            }

            var user = new User
            {
                UserName = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
            var addUser = await _userRepository.Register(user);

            var userRole = new UserRole
            {
                UserId = addUser.Id,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            var updateUser = await _userRepository.Update(user);



            var charityHome = new CharityHome
            {
                Image = model.Image,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Description = model.Description,
                IsApproved = false,
                IsDeleted = false,
                IsBan = false,
                UserId = addUser.Id,
                User = addUser,
                Category = category,
                CategoryId = category.Id,
            };
            

            var addCharityHome = await _charityHomeRepository.Register(charityHome);

            var mail = new EmailRequestModel
            {
                ReceiverEmail = model.Email,
                ReceiverName = $"{model.Name}",
                Message = $"@{model.Name} management, your registration is successful.\nKindly upload other information by clicking on the UPDATE button on your dashboard from the activation of your account.",
                Subject = "CMSApp-CMS CharityHome Registration",
            };
            await _email.SendEmail(mail);

            return new BaseResponse
            {
                Message = "CharityHome registration request sent successfully",
                Success = true
            };
        }
        public async Task<BaseResponse> UploadDocuments(UploadRequestModel model, int charityHomeId)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "File not attached",
                    Success = false
                };
            }

            foreach (var img in model.Documents)
            {
                var image = new Document
                {
                    Path = img,
                    CharityHomeId = charityHomeId
                };
                await _documentRepository.Register(image);
            }
            return new BaseResponse
            {
                Message = "Successfully uploaded",
                Success = true
            };
            
        }

        public async Task<BaseResponse> UpdateAddress(AddressRequestModel model, int id)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "fields cannot be null",
                    Success = false
                };
            }
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if(charityHome == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            
            charityHome.Address = model.Address;
            charityHome.LGA = model.LGA;
            charityHome.State = model.State;
            charityHome.City = model.City;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "Address Updated Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateBankDetails(AccountDetailsRequestModel model, int id)
        {
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "fields cannot be null",
                    Success = false
                };
            }
            var charityHome = await _charityHomeRepository.GetCharityHome(id);
            if (charityHome == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Account not found"
                };
            }
            charityHome.BankName = model.BankName;
            charityHome.AccountName = model.AccountName;
            charityHome.AccountNumber = model.AccountNumber;
            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "Details Uploaded Successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> Update(UpdateCharityHomeRequestModel model, int id)
        {
            var charityHome = await _charityHomeRepository.Get(x => x.Id == id);
            if (charityHome == null)
            {
                return new BaseResponse
                {
                    Message = "CharityHome not found",
                    Success = false
                };
            }
            if (model == null)
            {
                return new BaseResponse
                {
                    Message = "All fields cannot be null",
                    Success = false
                };
            }

            var category = await _categoryRepository.Get(x => x.Name == model.CategoryName);

            charityHome.Name = model.Name ?? charityHome.Name;
            charityHome.Password = model.Password ?? charityHome.Password;
            charityHome.State = model.State ?? charityHome.State;
            charityHome.City = model.City ?? charityHome.City;
            charityHome.LGA = model.LGA ?? charityHome.LGA;
            charityHome.Description = model.Description ?? charityHome.Description;
            charityHome.CategoryId = charityHome.CategoryId;
            charityHome.Particulars = (List<Document>)model.Documents ?? charityHome.Particulars;

            await _charityHomeRepository.Update(charityHome);
            return new BaseResponse
            {
                Message = "CharityHome information updated successfully",
                Success = true
            };
        }

        public async Task<CharityHomesResponseModel> GetBannedCharityHomes()
        {
            var charityHomes = await _charityHomeRepository.GetAll();
            if(charityHomes == null || charityHomes.Count == 0)
            {
                return new CharityHomesResponseModel
                {
                    Message = "List is Empty",
                    Success = false,
                };
            }
            var doc = await _documentRepository.GetAllWithCharityHome();
            var banned = charityHomes.Where(x => x.IsBan == true).Select(x => new CharityHomeDTO
            {
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                State = x.State,
                City = x.City,
                LGA = x.LGA,
                Address = x.Address,
                Id = x.Id,
                Particulars = doc.Select(a => new DocumentDTO
                {
                    Name = a.Name
                }).ToList(),
                Image = x.Image,
                AccountName = x.AccountName,
                AccountNumber = x.AccountNumber,
                BankName = x.BankName,
                IsApproved = x.IsApproved,
                IsBanned = x.IsBan,
                IsDeleted = x.IsDeleted,
                CategoryName = x.Category.Name,
                CategoryId = x.CategoryId,
                Description = x.Description,
            }).ToList();
            if(banned == null || banned.Count == 0)
            {
                return new CharityHomesResponseModel
                {
                    Message = "List is Empty",
                    Success = false
                };
            }
            return new CharityHomesResponseModel
            {
                Data = banned,
                Success = true,
                Message = "List of Baned CharityHomes",
            };
        }
    }
}