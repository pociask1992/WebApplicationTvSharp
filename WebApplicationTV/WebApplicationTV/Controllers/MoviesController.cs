using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTV.Models;
using WebApplicationTV.Services;

namespace WebApplicationTV.Controllers
{
    public class MoviesController : ApiController
    {
        private MoviesServices _movieService;

        public MoviesController()
        {
            _movieService = MoviesServices.Instance;
        }

        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            List<Movie> movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet, Route("movies/{movieId:int}")]
        public IHttpActionResult GetMovieById(int movieId)
        {
            Movie foundedMovie = _movieService.GetById(movieId);
            if (foundedMovie == null)
            {
                return NotFound();
            }

            return Ok(foundedMovie);
        }

        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]Movie movie)
        {
            _movieService.AddNewMovie(movie);
            return Ok();
        }

        [HttpDelete, Route("movies/{movieId:int}")]
        public IHttpActionResult DeleteMovie(int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return Ok();
        }

        [HttpPut, Route("movies")]
        public IHttpActionResult UpdateMovie([FromBody] Movie movie)
        {
            bool result = _movieService.UpdateMovie(movie);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
