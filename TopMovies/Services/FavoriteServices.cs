using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovies.Services
{
    public class FavoriteServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FavoriteServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public List<int> GetFavList()
        {
            var favs = _httpContextAccessor.HttpContext.Request.Cookies["favs"];
            if (string.IsNullOrEmpty(favs))
            {
                return new List<int>();
            }
            try
            {
                return favs.Split('-').Select(s => Convert.ToInt32(s)).ToList();

            }
            catch (Exception)
            {

                return new List<int>();
            }
        }
        public void SaveFavList(List<int> favorites)
        {
            string favs = string.Join('-', favorites);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("favs", favs, new CookieOptions() { Expires = DateTime.Now.AddYears(10) });
        }

    }
}
