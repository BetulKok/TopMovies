using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovies.Models
{
    public class HomeViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<GenreWithMovieCountViewModel> Genres { get; set; }
        public int? GenreId { get; set; }
    }
}
