using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //public IEnumerable<MovieDto> GetMovies() //string query = null)
        //{
        //    var moviesDto = _context.Movies
        //        .Include(m => m.Genre)
        //        .Where(m => m.NumberAvailable > 0)

        //    //if (!String.IsNullOrWhiteSpace(query))
        //    //    moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

        //    //return moviesQuery
        //        .ToList()
        //        .Select(Mapper.Map<Movie, MovieDto>);

        //    return moviesDto;
        //}

        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                          .Include(m => m.Genre)
                          .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return Ok(moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>));
            //var movieDto = _context.Movies
            //    .Include(m => m.Genre)
            //    .Where(m => m.NumberAvailable > 0)
            //    .ToList().Select(Mapper.Map<Movie, MovieDto>);
            //return Ok(movieDto);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
       [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}