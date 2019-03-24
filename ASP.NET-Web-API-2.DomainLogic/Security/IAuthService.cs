using System.Threading.Tasks;
using ASP.NET_Web_API_2.DataModel.User;

namespace ASP.NET_Web_API_2.DomainLogic.Security
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentials(string userName, string password, out User user);
    }
}
