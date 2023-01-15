using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiVideoGamesExcercise.Models
{
    public class VideoGameQueryParameters : QueryParameters
    {
        // public decimal? Size { get; set; }
        public decimal? Price { get; set; }
        public string SearchTerm { get; set; } = string.Empty;
    }
}