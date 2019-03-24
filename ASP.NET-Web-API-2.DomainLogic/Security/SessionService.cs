using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using ASP.NET_Web_API_2.DataAccess.User;
using ASP.NET_Web_API_2.DataModel.User;

namespace ASP.NET_Web_API_2.DomainLogic.Security
{
    public class SessionService
    {
        private UserDao _userDao;
        public UserDao UserDao => _userDao ?? (_userDao = new UserDao());
        public SessionService()
        {
            
        }

        public SessionService(UserDao userDao)
        {
            _userDao = userDao;
        }

        public User AddUser(string userName, string password)
        {
            
            try
            {
                ValidateExistingUserName(userName);

                System.Diagnostics.Debug.WriteLine("AddUser cu valorile : username=" + userName + " password=" + password);
                var rng = new RNGCryptoServiceProvider();
                
                User newUsr = new User();
                newUsr.UserName = userName;
                newUsr.Password = "";
                newUsr.Salt = "";
                return UserDao.SaveUser(user: newUsr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ValidateExistingUserName(string userName)
        {
            var isUserName = false;
            isUserName = UserDao.UserNameExists(userName);
            if (isUserName) { throw new WebException($"This user name: {userName} is already used!"); }
        }
    }
}
