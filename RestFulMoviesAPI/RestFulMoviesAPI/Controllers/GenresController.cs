using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using RestFulMoviesAPI.Entities;
using RestFulMoviesAPI.Filters;
using RestFulMoviesAPI.Services;

namespace RestFulMoviesAPI.Controllers
{
    //[Route("api/[controller]")] //this has the impact on client user calling api's if the class name changes at any point of time.
    [Route("api/genres")]
    [ApiController] //This is used to get away with ModelState.IsValid code multiple time in each Action method. This is applied at controller level.
    public class GenresController : ControllerBase //Inherited to return proper HTTP status codes.
    {
        private readonly IRepository repository;
        private readonly ILogger<GenresController> logger;

        public GenresController(IRepository repository, ILogger<GenresController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /*
         * With multiple endpoints for same HTTP request type, we use Routing Rules
         */
        [HttpGet]
        [HttpGet("list")] //can have multiple requests assigned to same action
        [HttpGet("/allgenres")] //overwrite the controller route with action specific route.
        [ServiceFilter(typeof(MyActionFilter))]//custom filters
        public async Task<ActionResult<List<Genre>>> GetGenres()
        {
            //Replace the return value types with ActionResult<T> or IActionResult to handle consistent result types in place of user defined types.
            return await repository.GetAllGenres();
        }

        [HttpGet("getgenre")] //can have a action specific routing rule to differentiate from similar action. this becomes : api/genres/getgenre
        public IActionResult GetGenreById(int Id)
        {
            //but here the action is being called, but the parameters are invalid
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                logger.LogWarning($"Genre with Id {Id} not found");
                //throw new ApplicationException();
                return NotFound(); 
            }
            return Ok(genre);
        }
        /*
         * Routing rules*/
        /*[HttpGet("{Id:int}/{param2=default}")] //with params. also we implement Routing constraint with data type.
        public ActionResult<Genre> GetGenreByParams(int Id, string param2)
        {
            //Most likely we will be using ActionResult<Tvalue> as this supports backward compatibility
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                return NotFound(); 
            }
            return genre;
        }*/
        /*ModelBinding using query strings + routing rules*/
        /*[HttpGet("{Id:int}")] //with params. also we implement Routing constraint with data type.
        public ActionResult<Genre> GetGenreByParams(int Id, [BindRequired]string param2)
        {
            //BindRequired is a must value in the query string
            //BindNever is used for the param tobe null/empty. Even if provided the param will be emtpy/null
            if(!ModelState.IsValid)//check the model state whether the input params were binded correctly/provided by user.
            {
                return BadRequest(ModelState);
            }
            //Most likely we will be using ActionResult<Tvalue> as this supports backward compatibility
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                return NotFound(); 
            }
            return genre;
        }*/
        /*ModelBinding using values from HTTP request*/
        [HttpGet("{Id:int}", Name ="getGenre")] //with params. also we implement Routing constraint with data type.
        public ActionResult<Genre> GetGenreByParams(int Id, [FromHeader]string param2)
        {
            //FromHeader : the parameter has to be added to Header of HTTP request
            //FromForm   : source willcome with content type applicationxwwww url
            //FromQuery  : query string 
            //FromBody   : Body of HTTP request
            //FromServices : dependency injection system
            //FromRoute  : Route Rule
            //Most likely we will be using ActionResult<Tvalue> as this supports backward compatibility
            var genre = repository.GetGenreById(Id);
            if (genre == null)
            {
                return NotFound();
            }
            return genre;
        }

        /*
         * Model Validation
         * Attributes for Validations
         * Required, StringLength, Range, CreditCard, Compare, Phone, RegularExpression, Url, BindRequired
         */

        [HttpPost]
        public IActionResult PostGenres([FromBody] Genre genre)
        {
            //for checking the values of the params, we do Model Validation

            repository.AddGenre(genre);
            
            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id}, genre);
        }

        [HttpPut]
        public IActionResult PutGenres()
        {
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteGenres()
        {
            return NoContent();
        }
    }
}
