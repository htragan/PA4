using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Databases;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        // GET: api/Songs
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            List<Song> mySongs = new List<Song>();
            mySongs.Add(new Song(){SongID = 1, SongTitle = "Enter Sandman", Deleted = "no", Favorited = "yes"});
            mySongs.Add(new Song(){SongID = 2, SongTitle = "Mr. Brightside", Deleted = "no", Favorited = "yes"});
            return mySongs;
        }

        // GET: api/Songs/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Songs
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            System.Console.WriteLine($"adding {value.SongTitle}");
        }

        // PUT: api/Songs/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song value)
        {
            System.Console.WriteLine($"updating book id {id} for {value.SongTitle}");
        }

        // DELETE: api/Songs/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
