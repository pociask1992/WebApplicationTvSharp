using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTV.Models;

namespace WebApplicationTV.Services
{
    public class MoviesServices
    {
        private static MoviesServices _instance;
        public List<Movie> _movies;

        public MoviesServices()
        {
            _movies = new List<Movie> { };


            Movie movie1 = new Movie()
             {
                 Id = 1,
                 Author = "Author1",
                 Title = "Title1",
                 Year = 1992,
                 Comments = new List<string> {"Very good film", "Very bad film" }
             };

            Movie movie2 = new Movie()
                {
                    Id = 2,
                    Author = "Author2",
                    Title = "Title2",
                    Year = 1993,
                    Comments = new List<string> {"Good good film 1"}
                };

            _movies.Add(movie1);
            _movies.Add(movie2);
        }

        public static MoviesServices Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MoviesServices();

                return _instance;
            }
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int movieId)
        {
            Movie foundedMovie = _movies.Where(movie => movie.Id == movieId).SingleOrDefault();
            return foundedMovie;
        }

        public void AddNewMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void DeleteMovie(int movieId)
        {
            Movie foundedMovie = GetById(movieId);
            _movies.Remove(foundedMovie);
        }
    }
}