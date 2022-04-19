using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Databases
{
    public class CreateSong : ICreateSongs
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con  = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, timestamp TEXT, deleted TEXT, favorited TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        
        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con  = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, timestamp, deleted, favorited) VALUES(@title, @timestamp, @deleted, @favorited)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@timestamp", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@favorited", song.Favorited);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
    }
}