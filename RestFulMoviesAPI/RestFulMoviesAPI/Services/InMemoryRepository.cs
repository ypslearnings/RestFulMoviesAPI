using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestFulMoviesAPI.Entities;

namespace RestFulMoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {

        private List<Genre> _genres;

        public InMemoryRepository()
        {
            _genres = new List<Genre>
            {
                new Genre(){ Id = 1, Name = "Comedy" },
                new Genre(){ Id = 2, Name = "Thriller" },
                new Genre(){ Id = 3, Name = "Romantic" },
                new Genre(){ Id = 4, Name = "Action" },
                new Genre(){ Id = 5, Name = "SciFi" },
            };
        }
        /*
         * Async programming
         *
         * return async along with Task to define the implementation will happen in future
         */
        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(1);//delaying response
            return _genres;
        }

        public Genre GetGenreById(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(x => x.Id) + 1;
            _genres.Add(genre);
        }
    }
}
