using Microsoft.EntityFrameworkCore;
using web_theater.Models;

namespace web_theater
{
    public class TheaterContext : DbContext //DbContext is a class from entity framwork
    {
        public DbSet<Movie> Movies {get; set;} //DbSet adds classes to the database

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=./Theaters.db"); //this is where you want to write the data to during development
                                                        //options.UseSqlServer("url") this would be for an actual database
        }
    }
}