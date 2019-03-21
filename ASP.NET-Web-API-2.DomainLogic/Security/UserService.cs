using System.Threading.Tasks;
using ASP.NET_Web_API_2.DataAccess.User;
using ASP.NET_Web_API_2.DataModel.User;

namespace ASP.NET_Web_API_2.DomainLogic.Security
{
    public class UserService: IUserService
    {
        private readonly UserDao _userDao;

        public UserService(UserDao userDao)
        {
            _userDao = userDao;
        }
        public Task<bool> ValidateCredentials(string userName, string password, out User user)
        {
            user = _userDao.GetByUserName(userName);
            return Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.Password));
        }
    }
}
