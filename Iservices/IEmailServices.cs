using sendEmail.Services;

namespace sendEmail.Iservices
{
    public interface IEmailServices
    {
        string sendEmail(string email);
    }
}
