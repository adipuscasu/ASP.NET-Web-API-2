using ASP.NET_Web_API_2.DataModel.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace ASP.NET_Web_API_2.DataAccess.Security
{
    public class RoleDao : AbstractDao, IRoleStore<Role>
    {
        public Task CreateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
