using CMSApplication.DTOs;
using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;
using CMSApplication.Entities;
using CMSApplication.Interfaces.Services;
using CMSApplication.Interfaces.Repositories;
using CMSApplication.Email;

namespace CMSApplication.Implementations.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ICharityHomeRepository _charityHomeRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IEmailSender _email;
        public AppointmentService(IAppointmentRepository appointmentRepository, ICharityHomeRepository charityHomeRepository, IDonorRepository donorRepository, IEmailSender email)
        {
            _appointmentRepository = appointmentRepository;
            _charityHomeRepository = charityHomeRepository;
            _donorRepository = donorRepository;
            _email = email;
        }

        public async Task<BaseResponse> ApproveAppointment(int id)
        {
            var appoint = await _appointmentRepository.GetById(id);
            if(appoint == null)
            {
                return new BaseResponse
                {
                    Message = "Appointment not found",
                    Success = false,
                };
            }
            appoint.IsApproved = true;
            await _appointmentRepository.Update(appoint);
            return new BaseResponse
            {
                Message = "Appointment approved",
                Success = true
            };
        }


        public async Task<AppointmentsResponseModel> GetAccomplishedByDonorId(int id)
        {
            var all = await _appointmentRepository.GetByDonorId(id);
            if (all.Count == 0)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment record",
                    Success = false
                };
            }
            var accomplished = all.Where(a => a.IsAccomplished == true && a.IsApproved == true ).Select(x => new AppointmentDTO
            {
                Time = x.Time,
                DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                DonorId = x.DonorId,
                CharityHomeId = x.CharityHomeId,
                CharityHomeName = $"{x.CharityHome.Name}",
                IsAccomplished = x.IsAccomplished,
                Id = x.Id,
            }).ToHashSet();
            return new AppointmentsResponseModel
            {
                Data = accomplished,
                Message = "Your appointments",
                Success = true
            };

        }

        public async Task<AppointmentsResponseModel> GetUnapprovedByCharityId(int id)
        {
            var all = await _appointmentRepository.GetByCharityHomeId(id);
            if (all == null)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment found",
                    Success = false,
                };
            }
            var unapproved = all.Where(a => a.IsApproved == false).Select(x => new AppointmentDTO
            {
                Time = x.Time,
                DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                DonorId = x.DonorId,
                CharityHomeId = x.CharityHomeId,
                CharityHomeName = $"{x.CharityHome.Name}",
                IsAccomplished = x.IsAccomplished,
                Id = x.Id,
            }).ToHashSet();
            if (unapproved == null)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment found",
                    Success = false,
                };
            }
            return new AppointmentsResponseModel
            {
                Message = "Unapproved Appointments",
                Success = true,
                Data = unapproved,
            };

        }

        public async Task<AppointmentsResponseModel> GetUnaccomplishedByDonorId(int id)
        {
            var all = await _appointmentRepository.GetByDonorId(id);
            if (all == null)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment record",
                    Success = false
                };
            }
            var unaccomplished = all.Where(a => a.IsAccomplished == false && a.IsApproved == true).Select(x => new AppointmentDTO
            {
                Time = x.Time,
                DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                DonorId = x.DonorId,
                CharityHomeId = x.CharityHomeId,
                CharityHomeName = $"{x.CharityHome.Name}",
                IsAccomplished = x.IsAccomplished,
                Id = x.Id,
            }).ToHashSet();
            return new AppointmentsResponseModel
            {
                Data = unaccomplished,
                Message = "Your appointments",
                Success = true
            };

        }

        public async Task<AppointmentsResponseModel> GetAccomplishedByCharityHomeId(int id)
        {
            var all = await _appointmentRepository.GetByCharityHomeId(id);
            if (all == null)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment record yet",
                    Success = false
                };
            }

            var accomplished = all.Where(a => a.IsAccomplished == true && a.IsApproved == true).Select(x => new AppointmentDTO
            {
                Time = x.Time,
                DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                DonorId = x.DonorId,
                CharityHomeId = x.CharityHomeId,
                CharityHomeName = $"{x.CharityHome.Name}",
                IsAccomplished = x.IsAccomplished,
                Id = x.Id,
            }).ToHashSet();
            return new AppointmentsResponseModel
            {
                Message = "Your appouintments",
                Success = true,
                Data = accomplished
            };
        }

        public async Task<AppointmentsResponseModel> GetUnaccomplishedByCharityHomeId(int id)
        {
            var all = await _appointmentRepository.GetByCharityHomeId(id);
            if (all == null)
            {
                return new AppointmentsResponseModel
                {
                    Message = "No appointment record yet",
                    Success = false
                };
            }

            var unaccomplished = all.Where(a => a.IsAccomplished == false && a.IsApproved == true).Select(x => new AppointmentDTO
            {
                Time = x.Time,
                DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                DonorId = x.DonorId,
                CharityHomeId = x.CharityHomeId,
                CharityHomeName = $"{x.CharityHome.Name}",
                IsAccomplished = x.IsAccomplished,
                Id = x.Id,
            }).ToHashSet();
            return new AppointmentsResponseModel
            {
                Message = "Your appointments",
                Success = true,
                Data = unaccomplished
            };
        }

        public async Task<AppointmentsResponseModel> GetAll()
        {
            var list = await _appointmentRepository.GetAll();
            if(list == null)
            {
                return new AppointmentsResponseModel
                {
                    Success = false,
                    Message = "No appointment found",
                    Data = null,
                };
            }

            return new AppointmentsResponseModel
            {
                Data = list.Select(x => new AppointmentDTO
                {
                    Time = x.Time,
                    DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                    DonorId = x.DonorId,
                    CharityHomeId = x.CharityHomeId,
                    CharityHomeName = $"{x.CharityHome.Name}",
                    IsAccomplished = x.IsAccomplished,
                    Id = x.Id,
                }).ToHashSet(),
                Success = true,
                Message = "List of Appointment"
            };
        }

        public async Task<AppointmentsResponseModel> GetByDonorId(int id)
        {
            var appointment = await _appointmentRepository.GetByDonorId(id);
            if (appointment == null)
            {
                return new AppointmentsResponseModel
                {
                    Success = false,
                    Message = "No appointment found",
                    Data = null,
                };
            }
            return new AppointmentsResponseModel
            {
                Data = appointment.Select(x => new AppointmentDTO
                {
                    Time = x.Time,
                    DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                    DonorId = x.DonorId,
                    CharityHomeId = x.CharityHomeId,
                    CharityHomeName = $"{x.CharityHome.Name}",
                    IsAccomplished = x.IsAccomplished,
                    Id = x.Id,
                    IsApproved = x.IsApproved,
                }).ToHashSet(),
                Success = true,
                Message = "List of Appointments"
            };

        }

        public async Task<AppointmentResponseModel> GetById(int id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if(appointment == null)
            {
                return new AppointmentResponseModel
                {
                    Message = "Appointment not found",
                    Success = false
                };
            }
            return new AppointmentResponseModel
            {
                Message = "",
                Data = new AppointmentDTO
                {
                    Time = appointment.Time,
                    Id = appointment.Id,
                    CharityHomeName = appointment.CharityHome.Name,
                    CharityHomeId = appointment.CharityHomeId,
                    DonorName = $"{appointment.Donor.FirstName} {appointment.Donor.LastName}",
                    DonorId = appointment.DonorId,
                    IsAccomplished = appointment.IsAccomplished,
                },
                Success = true,

            };
        }

        public async Task<AppointmentsResponseModel> GetByCharityHomeId(int id)
        {
            var appointment = await _appointmentRepository.GetByCharityHomeId(id);
            if (appointment == null)
            {
                return new AppointmentsResponseModel
                {
                    Success = false,
                    Message = "No appointment found",
                    Data = null,
                };
            }
            return new AppointmentsResponseModel
            {
                Data = appointment.Select(x => new AppointmentDTO
                {
                    Time = x.Time,
                    DonorName = $"{x.Donor.FirstName} {x.Donor.LastName}",
                    DonorId = x.DonorId,
                    CharityHomeId = x.CharityHomeId,
                    CharityHomeName = $"{x.CharityHome.Name}",
                    IsAccomplished = x.IsAccomplished,
                    Id = x.Id,
                }).ToHashSet(),
                Success = true,
                Message = "List of Appointments"
            };
        }

        public async Task<BaseResponse> CancelAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                return new BaseResponse
                {
                    Message = "Appointment does not exist",
                    Success = false
                };
            }

            appointment.IsDeleted = true;
            await _appointmentRepository.Update(appointment);
            return new BaseResponse
            {
                Message = "Appointment cancelled",
                Success = true
            };
        }

        public async Task<BaseResponse> MarkApproved(int id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                return new BaseResponse
                {
                    Message = "Appointment does not exist",
                    Success = false
                };
            }
            var charityHome = await _charityHomeRepository.GetCharityHome(appointment.CharityHomeId);

            await _charityHomeRepository.Update(charityHome);

            appointment.IsAccomplished = true;
            await _appointmentRepository.Update(appointment);

            var mail = new EmailRequestModel
            {
                ReceiverEmail = appointment.Donor.Email,
                ReceiverName = $"{appointment.Donor.FirstName} {appointment.Donor.LastName}",
                Message = $"Dear {appointment.Donor.FirstName}, your appointment with {appointment.CharityHome.Name} on {appointment.Time} has been marked approved, awaiting your kind visitation.\nThanks",
                Subject = "CMSApp-CMS Appointment Notification",
            };
            await _email.SendEmail(mail);

            return new BaseResponse
            {
                Message = "Donation made successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> UpdateAppointment(UpdateAppointmentRequestModel model, int id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                return new BaseResponse
                {
                    Message = "Appointment does not exist",
                    Success = false
                };
            }
            appointment.Time = model.Time;
            await _appointmentRepository.Update(appointment);
            return new BaseResponse
            {
                Message = "Appointment updated successfuly",
                Success = true
            };
        }

        public Task<BaseResponse> CreateAppointment(CreateAppointmentRequestModel model, int donorId, int requestId)
        {
            throw new NotImplementedException();
        }

        

        public Task<AppointmentsResponseModel> GetApprovedByDonorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponseModel> GetApprovedByCharityHomeId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponseModel> GetUnapprovedByCharityHomeId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsResponseModel> GetUnapprovedByDonorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
