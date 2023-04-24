using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
	public class AppDBContext : DbContext
	{
		public DbSet<Category> Categories { get; set; }

		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Call the base version of the method
			base.OnModelCreating(modelBuilder);

			// ======================================
			// Add seed Data
			// ======================================
			Category[] categoriesToSeed = new Category[3];

			for (int i = 1; i < 4; i++)
			{
				categoriesToSeed[i - 1] = new Category()
				{
					CategoryId = i,
					ThumbnailImagePath = "uploads/placeholder.jpg",
					Name = $"Category {i}",
					Description = $"A description of category {i}",
				};
			}

			// If data does not exist, seed it
			modelBuilder.Entity<Category>().HasData(categoriesToSeed);
		}
	}
}
