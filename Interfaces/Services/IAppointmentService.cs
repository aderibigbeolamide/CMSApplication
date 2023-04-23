using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<BaseResponse> CreateAppointment(CreateAppointmentRequestModel model, int donorId, int requestId);
        Task<BaseResponse> UpdateAppointment(UpdateAppointmentRequestModel model, int id);
        Task<AppointmentResponseModel> GetById(int id);
        Task<AppointmentsResponseModel> GetAll();
        Task<AppointmentsResponseModel> GetByCharityHomeId(int id);
        Task<AppointmentsResponseModel> GetByDonorId(int id);
        Task<AppointmentsResponseModel> GetApprovedByDonorId(int id);
        Task<AppointmentsResponseModel> GetApprovedByCharityHomeId(int id);
        Task<AppointmentsResponseModel> GetUnapprovedByCharityHomeId(int id);
        Task<AppointmentsResponseModel> GetUnapprovedByDonorId(int id);
        Task<BaseResponse> ApproveAppointment(int id);
        Task<BaseResponse> MarkApproved(int id);
        Task<BaseResponse> CancelAppointment(int id);
    }
}
