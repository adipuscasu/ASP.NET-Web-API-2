using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Web_API_2.DataAccess
{
    public class AbstractDao
    {
        public string ConnectionString { get; set; }

        public int ExecuteStoredProcedure(string spName, int timeOut = 50, params SqlParameter[] parameters)
        {
            using (var newConnection = new SqlConnection(ConnectionString))
            using (var newCommand = new SqlCommand(spName, newConnection))
            {
                newCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null) newCommand.Parameters.AddRange(parameters);

                newConnection.Open();
                newCommand.CommandTimeout = timeOut != 50 ? timeOut: 50;
                
                return newCommand.ExecuteNonQuery();
            }
        }

        public DataTable FetchDataTable(string spName, params SqlParameter[] parameters)
        {
            return FetchDataTableTimeout(spName, 50, parameters);
        }

        public DataTable FetchDataTableTimeout(string spName, int timeOut = 50, params SqlParameter[] parameters)
        {
            using (var newConnection = new SqlConnection(ConnectionString))
            using (var newCommand = new SqlCommand(spName, newConnection))
            {
                var dt = new DataTable();
                var adapter = new SqlDataAdapter();
                newCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null) newCommand.Parameters.AddRange(parameters);

                newConnection.Open();
                newCommand.CommandTimeout = timeOut != 50 ? timeOut: 50;
                adapter.SelectCommand = newCommand;
                using (adapter)
                {
                    adapter.Fill(dt);
                    return dt;
                }
                
            }
        }



        public async Task<int> ExecuteStoredProcedureAsync(string spName, params SqlParameter[] parameters)
        {
            using (var newConnection = new SqlConnection(ConnectionString))
            using (var newCommand = new SqlCommand(spName, newConnection))
            {
                newCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null) newCommand.Parameters.AddRange(parameters);

                await newConnection.OpenAsync().ConfigureAwait(false);
                return await newCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
    }
}
