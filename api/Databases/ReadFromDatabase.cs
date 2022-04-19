using System;
using System.IO;
using System.Collections.Generic;
using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Databases
{
    public class ReadFromDatabase : IReadSongs
    {
        public List<Song> GetAll()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con  = new MySqlConnection(cs);
            con.Open();

            List<Song> songs = new List<Song>();

            string stm = @"SELECT * from songs";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();

            return songs;
        }

        public Song GetOne(int id)
        {

            List<Song> songs = new List<Song>();
            return songs.Find(x => x.SongID == id);
        }
    }
}