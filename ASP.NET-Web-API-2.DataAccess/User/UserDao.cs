using ASP.NET_Web_API_2.DataModel.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Web_API_2.DataAccess.User
{
    public class UserDao : AbstractDao
    {
        public bool IsValid(DataModel.User.User user)
        {
            throw new NotImplementedException();
        }

        public DataModel.User.User GetByUserName(string userName)
        {
            var conn = new SqlConnection(ConnectionString);
            const string sqlCommand = "User_GetByUserName";
            var cmd = new SqlCommand(sqlCommand, conn) { CommandType = CommandType.StoredProcedure };
            var param = new SqlParameter("@userName", SqlDbType.NVarChar) { Value = userName };
            cmd.Parameters.Add(param);
            var user = new DataModel.User.User();
            var dataTable = new DataTable();
            using (conn)
            {
                try
                {
                    conn.Open();
                    //var cmd = cmdContainer.BuildCommandStoredProcedure(parameters);
                    using (cmd)
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dataTable);
                            if (dataTable.Rows.Count > 0)
                            {
                                var dataRow = dataTable.Rows[0];
                                user = new DataModel.User.User(dataRow);
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

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

    }
}
