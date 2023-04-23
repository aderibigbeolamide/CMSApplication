using CMSApplication.DTOs;
using CMSApplication.DTOs.RequestModel;
using CMSApplication.DTOs.ResponseModel;

namespace CMSApplication.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaystackResponse> MakePayment(DonationPaymentRequestModel model, int donationId);
        Task<MakePayment> SendMoney(string reciept, decimal amount);
        Task<Receipt> GenerateReceipt(BankVerification verifyBank);
        Task<BankVerification> VerifyAccountNumber(string acNumber, string bankCode, decimal amount);
    }
}
