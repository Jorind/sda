using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestApiVideoGamesExcercise.Entities;

namespace RestApiVideoGamesExcercise.Entities
{
    public partial class VideoGamesContext : DbContext
    {
        public VideoGamesContext()
        {
        }

        public VideoGamesContext(DbContextOptions<VideoGamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VideoGame> VideoGames { get; set; }
        public virtual DbSet<VideoGameStudio> VideoGameStudios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            });

            modelBuilder.Entity<VideoGameStudio>(entity =>
            {
                entity.ToTable("VideoGameStudio");

                entity.Property(e => e.StudioName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Seed();


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
