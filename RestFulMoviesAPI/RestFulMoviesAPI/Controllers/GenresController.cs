using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestFulMoviesAPI.Entities;
using RestFulMoviesAPI.Services;

namespace RestFulMoviesAPI.Controllers
{
    //[Route("api/[controller]")] //this has the impact on client user calling api's if the class name changes at any point of time.
    [Route("api/genres")]
    public class GenresController : ControllerBase //Inherited to return proper HTTP status codes.
    {
        private readonly IRepository repository;

        public GenresController(IRepository repository)
        {
            this.repository = repository;
        }

        /*
         * With multiple endpoints for same HTTP request type, we use Routing Rules
         */
        [HttpGet]
        [HttpGet("list")] //can have multiple requests assigned to same action
        [HttpGet("/allgenres")] //overwrite the controller route with action specific route.
        public List<Genre> GetGenres()
        {
            return repository.GetAllGenres();
        }

        [HttpGet("getgenre")] //can have a action specific routing rule to differentiate from similar action. this becomes : api/genres/getgenre
        public Genre GetGenreById(int Id)
        {
            //but here the action is being called, but the parameters are invalid
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                //return NotFound(); 
            }
            return genre;
        }

        [HttpGet("{Id:int}/{param2=default}")] //with params. also we implement Routing constraint with data type.
        public Genre GetGenreByParams(int Id, string param2)
        {
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                //return NotFound(); 
            }
            return genre;
        }

        [HttpPost]
        public void PostGenres()
        {
        }

        [HttpPut]
        public void PutGenres()
        {

        }

        [HttpDelete]
        public void DeleteGenres()
        {

        }
    }
}
