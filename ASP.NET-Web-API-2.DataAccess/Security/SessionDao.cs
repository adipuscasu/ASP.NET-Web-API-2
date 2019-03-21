using ASP.NET_Web_API_2.DataModel.Security;

namespace ASP.NET_Web_API_2.DataAccess.Security
{
    public class SessionDao: AbstractDao
    {
        public Session Login(DataModel.User.User user)
        {
            var session = new Session();
            return session;
        }
    }
}
