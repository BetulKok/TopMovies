using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TopMovies.Models;

namespace TopMovies.Areas.Admin.Models
{
    public class EditMovieViewModel
    {

        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string ImdbId { get; set; }

        [Required, MaxLength(400)]
        public string Name { get; set; }

        public int? Year { get; set; }

        public decimal? Rating { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public List<Genre> Genres { get; set; }
        public int[] SelectedGenres { get; set; } = Array.Empty<int>();

    }
}
