using System.Configuration;

namespace GuildCars.Data
{
    public class Settings // getting and setting the connection string and the type of repository. 
    {
        private static string _connectionString { get; set; }
        private  static string _repositoryType { get; set; }

        public static string GetConnectionString() 
        {
            if (string.IsNullOrEmpty(_connectionString)) // if there is no connection string 
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; // set to default 
            }
            return _connectionString;
        }

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
            {
                _repositoryType = ConfigurationManager.AppSettings["Mode"].ToString(); // mode will be Prod or QA/TEST
            }

            return _repositoryType;
        }
    }
}
