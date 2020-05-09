using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Genre> GetAllGenres()
        {
            return _genres;
        }

        public Genre GetGenreById(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }
    }
}
