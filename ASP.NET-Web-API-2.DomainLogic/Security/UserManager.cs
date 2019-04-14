using System.Threading.Tasks;
using ASP.NET_Web_API_2.DataAccess.User;
using ASP.NET_Web_API_2.DataModel.User;

namespace ASP.NET_Web_API_2.DomainLogic.Security
{
    public class UserManager: IUserService
    {
        private readonly UserDao _userDao;

        public UserManager(UserDao userDao)
        {
            _userDao = userDao;
        }

        public Task SaveUser(User user)
        {
            return null;
        }
    }
}
