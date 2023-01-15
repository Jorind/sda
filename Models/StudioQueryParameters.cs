using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiVideoGamesExcercise.Models
{
    public class StudioQueryParameters : QueryParameters
    {
        public string StudioName { get; set; } = string.Empty;

        public bool? IsActive { get; set; }
    }
}