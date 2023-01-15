using System;
using System.Collections.Generic;

namespace RestApiVideoGamesExcercise.Entities
{
    public partial class VideoGameStudio
    {
        public VideoGameStudio()
        {
            VideoGames = new HashSet<VideoGame>();
        }

        public int Id { get; set; }
        public string StudioName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}
