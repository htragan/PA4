using System.Collections.Generic;
using System;
using System.IO;
using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Databases
{
    public class WriteToDatabase
    {
        public static void WriteAllToDatabase(List<Song> Playlist) 
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con  = new MySqlConnection(cs);
            con.Open();

            foreach (Song song in Playlist) 
            {
                string stm = @"INSERT INTO songs(id, title, timestamp, deleted, favorited) VALUES(@id, @title, @timestamp, @deleted, @favorited)";

                using var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@id", song.SongID);
                cmd.Parameters.AddWithValue("@title", song.SongTitle);
                cmd.Parameters.AddWithValue("@timestamp", song.SongTimestamp);
                cmd.Parameters.AddWithValue("@deleted", song.Deleted);
                cmd.Parameters.AddWithValue("@favorited", song.Favorited);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }            
        } 
    }
}