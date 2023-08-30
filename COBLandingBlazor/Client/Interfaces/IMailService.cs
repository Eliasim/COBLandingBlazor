using COBLandingBlazor.Client.Model;

namespace COBLandingBlazor.Client.Interfaces
{
    public interface IMailService
    {
        Task<bool> Email(EmailBody email);
    }
}
