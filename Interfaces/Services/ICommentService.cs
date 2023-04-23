using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface ICommentService
    {
        Task<BaseResponse> CreateComment(CreateCommentRequestModel model, int donorId, int charityHomeId);
        Task<BaseResponse> UpdateComment(UpdateCommentRequestModel model, int id);
        Task<CommentsResponseModel> GetCommentByCharityHomeId(int id);
        Task<CommentsResponseModel> GetCommentsByContent(string content);
        Task<CommentsResponseModel> GetAll();
        Task<CommentResponseModel> GetComment(int id);
    }
}
