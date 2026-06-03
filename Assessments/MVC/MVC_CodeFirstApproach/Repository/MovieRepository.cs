using MVC_CodeFirstApproach.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVC_CodeFirstApproach.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MovieContext db = new MovieContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);

            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies
                     .Where(m => m.DateOfRelease.Year == year)
                     .ToList();
        }

        public IEnumerable<Movie> GetByDirector(string director)
        {
            return db.Movies
                     .Where(m => m.DirectorName == director)
                     .ToList();
        }
    }
}