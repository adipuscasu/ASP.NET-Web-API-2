using System.Configuration;

namespace ASP.NET_Web_API_2.DataAccess
{
    public class AbstractDao
    {
        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;
                // Look for the name in the connectionStrings section.
                var settings =
                    ConfigurationManager.ConnectionStrings["ASP.NET-Web-API-2"];

                // If found, return the connection string.
                if (settings != null)
                    _connectionString = settings.ConnectionString;

                return _connectionString;
            }
            set => _connectionString = value;
        }


    }
}
