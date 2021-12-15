using NaturaApp.Common.Models;

namespace NaturaApp.Api.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
