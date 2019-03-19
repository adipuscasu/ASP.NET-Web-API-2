using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ASP.NET_Web_API_2.DataModel.SqlHelper
{
    public class CommandContainer
    {
        private string _command;
        private SqlConnection _sqlConnection;

        public CommandContainer(string command, SqlConnection sqlConnection)
        {
            _command = command;
            _sqlConnection = sqlConnection;
        }

        public SqlCommand BuildCommandStoredProcedure(List<SqlParameter> parameters)
        {
            var sqlCommand = new SqlCommand(_command, _sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            foreach (var sqlParameter in parameters)
            {
                sqlCommand.Parameters.Add(sqlParameter);
            }

            return sqlCommand;
        }
    }
}
