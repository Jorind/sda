using Microsoft.EntityFrameworkCore;
using RestApiVideoGamesExcercise.Entities;

namespace RestApiVideoGamesExcercise.Entities
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGameStudio>().HasData(
                new VideoGameStudio { Id = 1, StudioName = "XXX" },
                new VideoGameStudio { Id = 2, StudioName = "YYY" }
                );

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Name = "Counter Strike", Size = 2000, VideoGameStudioId = 1, Price = 50 },
                new VideoGame { Id = 2, Name = "Pro Evolution", Size = 2100, VideoGameStudioId = 1, Price = 55 },
                new VideoGame { Id = 3, Name = "FIFA", Size = 2200, VideoGameStudioId = 1, Price = 60 },
                new VideoGame { Id = 4, Name = "Call of Duty", Size = 2300, VideoGameStudioId = 1, Price = 65 },
                new VideoGame { Id = 5, Name = "Blur", Size = 2400, VideoGameStudioId = 1, Price = 70 },
                new VideoGame { Id = 6, Name = "Assasin Creed", Size = 2500, VideoGameStudioId = 1, Price = 75 });
        }
    }
}
