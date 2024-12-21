namespace techwork_after_america_return.Services
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }
}