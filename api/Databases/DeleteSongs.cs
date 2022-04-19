using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.Databases
{
    public class DeleteSongs : IDeleteSongs
    {
        public static void DropSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con  = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con  = new MySqlConnection(cs);

            con.Open();

            string stm = @$"DELETE FROM songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}