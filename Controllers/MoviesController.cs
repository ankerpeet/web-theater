using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_theater.Models;

namespace web_theater.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        public TheaterContext _db { get; private set; }

        // List<Movie> Values = new List<Movie>() { 
        //     new Movie("ET", "An alien and a Boy"),
        //     new Movie("IT", "A clown and several boys"),
        //     new Movie("Lassie", "A dog and a boy")
        // };
        public MoviesController(TheaterContext db) //required stuff to make it work
        {
            _db = db;
            // Values.Add(new Movie("Blade", "Some Vampires and a boy"));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _db.Movies;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _db.Movies.Find(id);
        }

        [HttpGet("{banana}")]
        public IEnumerable<Movie> Get(string banana)
        {
            return _db.Movies.Where(m => m.Title.Contains(banana)).ToList();
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Movie value)
        {
            // Values.Add(value);
            _db.Movies.Add(value);
            _db.SaveChanges();
            return "Success";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Movie value)
        {
            var movie = _db.Movies.Find(id);
            if(movie != null)
            {
                movie.Title = value.Title;
                movie.Description = value.Description;
                _db.SaveChanges();
                return "success";
            }
            return "That didn't work";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
