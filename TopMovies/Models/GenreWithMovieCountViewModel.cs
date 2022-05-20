using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopMovies.Models
{
    public class GenreWithMovieCountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieCount { get; set; }
    }
}
