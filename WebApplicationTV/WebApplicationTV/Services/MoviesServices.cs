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

            _movies.Add(
                new Movie()
                {
                    Id = 1,
                    Author = "Author1",
                    Title = "Title1",
                    Year = 1992,
                    Comments = { "Very good film", "Very bad film"}
                });

            _movies.Add(
                new Movie()
                {
                    Id =2,
                    Author="Author2",
                    Title="Title2",
                });
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