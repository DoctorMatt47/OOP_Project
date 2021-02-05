using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NextWave.Models;
using NextWave.Models.Entities;

namespace NextWave.Domain
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<ProfileIcon> Icons { get; set; }
        public DbSet<QueueType> QueueTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Champion>(x =>
            {
                var champions = JsonParser.GetChampionsFromJson();
                foreach (var champion in champions)
                {
                    x.HasData(new Champion()
                    {
                        Id = champion.Id,
                        Key = champion.Key,
                        Name = champion.Name,
                    });

                    x.OwnsOne(y => y.Image).HasData(new
                    {
                        ChampionId = champion.Id,
                        Full = champion.Image.Full,
                        Sprite = champion.Image.Sprite,
                        X = champion.Image.X,
                        Y = champion.Image.Y,
                        H = champion.Image.H,
                        W = champion.Image.W
                    });
                }
            });

            modelBuilder.Entity<ProfileIcon>(x =>
            {
                var icons = JsonParser.GetIconsFromJson();
                foreach (var icon in icons)
                {
                    x.HasData(new ProfileIcon()
                    {
                        Id = icon.Id
                    });

                    x.OwnsOne(y => y.Image).HasData(new
                    {
                        ProfileIconId = icon.Id,
                        Full = icon.Image.Full,
                        Sprite = icon.Image.Sprite,
                        X = icon.Image.X,
                        Y = icon.Image.Y,
                        H = icon.Image.H,
                        W = icon.Image.W
                    });
                }
            });

            modelBuilder.Entity<QueueType>(x =>
                x.HasData(JsonParser.GetQueueTypesFromJson()));
        }
    }
}
