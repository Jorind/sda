using System;
using System.Collections.Generic;

namespace RestApiVideoGamesExcercise.Entities
{
    //These models are a reflection of the database tables.
    //For that reason, they are considered Entities, and moved from the Models folder to the Entities folder
    public class VideoGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }

        public decimal Price { get; set; }

        public int VideoGameStudioId { get; set; }
        public virtual VideoGameStudio VideoGameStudio { get; set; }
    }
}
