using System;
using System.Collections.Generic;
using RestFulMoviesAPI.Entities;

namespace RestFulMoviesAPI.Services
{
    public interface IRepository
    {
        List<Genre> GetAllGenres();
        Genre GetGenreById(int Id);
    }
}
