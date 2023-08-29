
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WebApplication2.Models;

namespace WebApplication2
{
	public class DbTestContext : IdentityDbContext<UserModel>
	{
		public DbTestContext(DbContextOptions<DbTestContext> options) : base(options)
		{

		}

		public DbSet<News> NewsList { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<UserRead> UserReads {get; set;}
        public DbSet<Comment> Comments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserRead>()
				.HasKey(urn => new { urn.UserId, urn.NewsId });

			modelBuilder.Entity<UserRead>()
				.HasOne(urn => urn.User)
				.WithMany(u => u.ReadNews)
				.HasForeignKey(urn => urn.UserId);

			modelBuilder.Entity<UserRead>()
				.HasOne(urn => urn.News)
				.WithMany()
				.HasForeignKey(urn => urn.NewsId);
            modelBuilder.Entity<Image>()
				.HasOne(i => i.News)
				.WithMany(n => n.Images)
				.HasForeignKey(i => i.NewsId);
        }
	}
}
