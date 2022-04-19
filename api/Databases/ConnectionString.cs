using MySql.Data.MySqlClient;

namespace api.Databases
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString()
        {
            string server = "x8autxobia7sgh74.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "ft1po34q2ye0u6of";
            string port = "3306";
            string username = "ptfnohx2abx8wwfr";
            string password = "qdlzlf5fe2n0hyr9";

            cs = $@"server = {server}; user = {username}; database = {database}; port = {port}; password = {password}";
        }
    }
}