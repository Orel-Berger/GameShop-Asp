using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebFinal.Models;


namespace WebFinal.Data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
        }
        //create table in sql 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }


        //insert data to table in sql
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "Action", CategoryDate = DateTime.Now },
                new { Id = 2, Name = "Casual", CategoryDate = DateTime.Now },
                new { Id = 3, Name = "Card Game", CategoryDate = DateTime.Now },
                new { Id = 4, Name = "Shooting", CategoryDate = DateTime.Now },
                new { Id = 5, Name = "Race", CategoryDate = DateTime.Now }
                );

            modelBuilder.Entity<Game>().HasData(
                new { Id = 1, Title = "Gta", Description = "Grand Theft Auto (usually abbreviated GTA) is a series of games that incorporate driving and action gameplay styles. Created by the British developer Rockstar North, GTA games are set in vast, predominantly urban 'sandbox' environments, and feature protagonists involved in organized crime.", Publisher = "Rockstar", PublishDate = DateTime.Now, Price = 100.0, ImageUrl = @"images\games\pic1.png", CategoryId = 5 },
                new { Id = 2, Title = "Fortnite", Description = "In Fortnite, players collaborate to survive in an open-world environment, by battling other characters who are controlled either by the game itself, or by other players.", Publisher = "Epic Games", PublishDate = DateTime.Now, Price = 90.0, ImageUrl = @"images\games\pic2.png", CategoryId = 4 },
                new { Id = 3, Title = "Apex legends", Description = "Apex Legends is an online multiplayer battle royale game featuring squads of three players using pre-made characters with distinctive abilities, called 'Legends', similar to those of hero shooters. ", Publisher = "Taki", PublishDate = DateTime.Now, Price = 5.0, ImageUrl = @"images\games\pic3.png", CategoryId = 1 },
                new { Id = 4, Title = "Need For Speed", Description = "Need for Speed (NFS) is a racing game franchise published by Electronic Arts and currently developed by Criterion Games, the developers of Burnout.", Publisher = "Ford", PublishDate = DateTime.Now, Price = 120.0, ImageUrl = @"images\games\pic4.png", CategoryId = 2 },
                new { Id = 5, Title = "Rocket League", Description = "Rocket League is a fantastical sport-based video game, developed by Psyonix (it's “soccer with cars”). It features a competitive game mode based on teamwork and outmaneuvering opponents.", Publisher = "Kodkod", PublishDate = DateTime.Now, Price = 150.5, ImageUrl = @"images\games\pic5.png", CategoryId = 3 }
                );
            modelBuilder.Entity<Comment>().HasData(
                    new { Id = 1,Description = "The Best Game Ever",PublishDate = DateTime.Now, Rating = 5,GameId = 5 },
                    new { Id = 2,Description = "I will buy It For  my son",PublishDate = DateTime.Now, Rating = 4,GameId = 4 },
                    new { Id = 3,Description = "little expensive ",PublishDate = DateTime.Now, Rating = 5,GameId = 2 },
                    new { Id = 4,Description = "Good game",PublishDate = DateTime.Now, Rating = 3,GameId = 2 },
                    new { Id = 5,Description = "thanks for game",PublishDate = DateTime.Now, Rating = 4,GameId = 1 },
                    new { Id = 6,Description = "can i play it from school?", PublishDate = DateTime.Now, Rating = 5, GameId = 5 },
                    new { Id = 7,Description = "the best gift ever", PublishDate = DateTime.Now, Rating = 4, GameId = 4 },
                    new { Id = 8,Description = "What the price?", PublishDate = DateTime.Now, Rating = 5, GameId = 2 },
                    new { Id = 9,Description = "when will be asale", PublishDate = DateTime.Now, Rating = 3, GameId = 2 },
                    new { Id = 10,Description = "can i get the game for free", PublishDate = DateTime.Now, Rating = 4, GameId = 1 },
                    new { Id = 11, Description = "very good game", PublishDate = DateTime.Now, Rating = 5, GameId = 5 },
                    new { Id = 12, Description = "amazing Game", PublishDate = DateTime.Now, Rating = 4, GameId = 4 },
                    new { Id = 13, Description = "that agame!!!", PublishDate = DateTime.Now, Rating = 5, GameId = 2 },
                    new { Id = 14, Description = "I didnt like the game", PublishDate = DateTime.Now, Rating = 1, GameId = 2 },
                    new { Id = 15, Description = "The Best Game Ever!!!!", PublishDate = DateTime.Now, Rating = 4, GameId = 1 }
                    );
        }
    }
}