using CMSApp.DTOs;
using CMSApp.DTOs.RequestModel;
using CMSApp.DTOs.ResponseModel;

namespace CMSApp.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaystackResponse> MakePayment(DonationPaymentRequestModel model, int donationId);
        Task<MakePayment> SendMoney(string reciept, decimal amount);
        Task<Receipt> GenerateReceipt(BankVerification verifyBank);
        Task<BankVerification> VerifyAccountNumber(string acNumber, string bankCode, decimal amount);
    }
}
