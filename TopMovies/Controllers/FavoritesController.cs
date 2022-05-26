using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopMovies.DTO_s;
using TopMovies.Models;
using TopMovies.Services;

namespace TopMovies.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly FavoriteServices _favoriteServices;

        public FavoritesController(ApplicationDbContext db, FavoriteServices favoriteServices)
        {
            _db = db;
            _favoriteServices = favoriteServices;
        }
        public IActionResult Index()
        {
            List<int> favs = _favoriteServices.GetFavList();
            List<Movie> movies = _db.Movies
                .Where(x => favs.Contains(x.Id))
                .ToList();
            return View(movies);

        }
        [HttpPost]
        public IActionResult Toggle( int movieId)
        {
            List<int> favs = _favoriteServices.GetFavList();
            bool fav;
            if (favs.Contains(movieId))
            {
                favs.Remove(movieId);
                fav = false;
            }
            else
            {
                favs.Add(movieId);
                fav= true;
            }
            _favoriteServices.SaveFavList(favs);
            return Json( new FavoriteToggleResult{ Favorited = fav });
        }

        
    }
}
