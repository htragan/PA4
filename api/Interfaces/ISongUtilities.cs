using System.Collections.Generic;
using api.Models;

namespace PA4.Interfaces
{
    public interface ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void FavoriteSong();
         public void PrintPlaylist();
    }
}