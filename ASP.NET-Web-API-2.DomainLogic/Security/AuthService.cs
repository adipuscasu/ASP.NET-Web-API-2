﻿using System.Threading.Tasks;
using ASP.NET_Web_API_2.DataAccess.User;
using ASP.NET_Web_API_2.DataModel.User;

namespace ASP.NET_Web_API_2.DomainLogic.Security
{
    public class AuthService: IAuthService
    {
        private readonly UserDao _userDao;

        public AuthService(UserDao userDao)
        {
            _userDao = userDao;
        }
        public Task<bool> ValidateCredentials(string userName, string password, out User user)
        {
            user = _userDao.GetByUserName(userName);
            return string.IsNullOrEmpty(user.Password)
                ? Task.FromResult(false)
                : Task.FromResult(BCrypt.Net.BCrypt.Verify(password, user.Password));
        }
    }
}
