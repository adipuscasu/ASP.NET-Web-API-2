using ASP.NET_Web_API_2.DataModel.SqlHelper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Web_API_2.DataAccess.User
{
    public class UserDao : AbstractDao, IUserStore<DataModel.User.User>
    {
        public bool IsValid(DataModel.User.User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the user identified by the userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataModel.User.User GetByUserName(string userName)
        {
            const string sqlCommand = "User_GetByUserName";

            var parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@userName", SqlDbType.NVarChar, 256) { Value = userName };;

            var user = new DataModel.User.User();
            var dataTable = FetchDataTable(sqlCommand, parameters);

            if (dataTable.Rows.Count <= 0) return user;

            var dataRow = dataTable.Rows[0];
            user = new DataModel.User.User(dataRow);

            return user;
        }

        public async Task SaveUser(DataModel.User.User user)
        {
            const string sqlCommand = "User_Save";
            var parameters = BuildParametersForSaveUser(user);
            var conn = new SqlConnection(ConnectionString);
            using (conn)
            {

                await conn.OpenAsync();
                var tx = conn.BeginTransaction();
                try
                {
                    var cmdContainer = new CommandContainer(sqlCommand, conn);
                    var cmd = cmdContainer.BuildCommandStoredProcedure(parameters);
                    cmd.Transaction = tx;
                    var id = await cmd.ExecuteScalarAsync();
                    tx.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    tx.Rollback();
                }
            }
        }

        public bool UserNameExists(string userName)
        {
            const string sqlCommand = "User_UserNameExists @userName = @userName";
            var paramUserName = new SqlParameter("@userName", SqlDbType.NVarChar) { Value = userName };
            var parameters = new List<SqlParameter> { paramUserName };
            var conn = new SqlConnection(ConnectionString);
            var isUserName = false;
            using (conn)
            {
                try
                {
                    conn.Open();
                    var cmdContainer = new CommandContainer(sqlCommand, conn);
                    var cmd = cmdContainer.BuildCommandStoredProcedure(parameters);
                    using (cmd)
                    {
                        isUserName = (bool)cmd.ExecuteScalar();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            return isUserName;
        }



        private static List<SqlParameter> BuildParametersForSaveUser(DataModel.User.User user)
        {
            var paramUserName = new SqlParameter("@userName", SqlDbType.NVarChar, 100) { Value = user.UserName };
            var paramPassword = new SqlParameter("@userName", SqlDbType.NVarChar, 250) { Value = user.Password };
            var parameters = new List<SqlParameter> { paramUserName, paramPassword };
            return parameters;
        }

        public Task CreateAsync(DataModel.User.User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DataModel.User.User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DataModel.User.User user)
        {
            throw new NotImplementedException();
        }

        public Task<DataModel.User.User> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<DataModel.User.User> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
