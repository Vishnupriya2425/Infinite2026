using MVC_CodeFirstApproach.Models;
using System.Collections.Generic;

namespace MVC_CodeFirstApproach.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();

        Movie GetById(int id);

        void Insert(Movie movie);

        void Update(Movie movie);

        void Delete(int id);

        IEnumerable<Movie> GetByYear(int year);

        IEnumerable<Movie> GetByDirector(string director);
    }
}