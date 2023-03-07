namespace CMSApp.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailRequestModel email);
    }
}
