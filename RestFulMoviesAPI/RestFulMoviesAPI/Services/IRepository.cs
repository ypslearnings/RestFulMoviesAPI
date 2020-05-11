using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestFulMoviesAPI.Entities;

namespace RestFulMoviesAPI.Services
{
    public interface IRepository
    {
        void AddGenre(Genre genre);
        Task<List<Genre>> GetAllGenres();
        Genre GetGenreById(int Id);
    }
}
