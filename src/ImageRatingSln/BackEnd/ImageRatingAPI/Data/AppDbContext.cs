using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Xml;

namespace ImageRatingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate(); //EnsureCreated();
        }

        //protected override void OnModelCreating()
        //{

        //}

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<ImageSourceEntity> ImageSources { get; set; }
        public DbSet<UserImageRatingEntity> UserImageRatings { get; set; }
    }
}
