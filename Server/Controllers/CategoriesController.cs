using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly AppDBContext _appDBContext;
		public CategoriesController(AppDBContext appDBContext)
		{
			_appDBContext = appDBContext;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			// Return categories from database
			List<Category> categories = await _appDBContext.Categories.ToListAsync();

			return Ok(categories);
		}

		[HttpGet("withposts")] // website.com/api/categories/withposts
		public async Task<IActionResult> GetWithPosts()
		{
			// Return categories from database
			List<Category> categories = await _appDBContext.Categories.Include(category => category.Posts).ToListAsync();

			return Ok(categories);
		}

		[HttpGet("{id}")] // website.com/api/categories/3
		public async Task<IActionResult> Get(int id)
		{
			Category category = await GetCategoryByCategoryId(id, false);

			return Ok(category);
		}

		[HttpGet("withposts/{id}")] // website.com/api/categories/withposts/3
		public async Task<IActionResult> GetWithPosts(int id)
		{
			Category category = await GetCategoryByCategoryId(id, true);

			return Ok(category);
		}
		#region Utility Methods

		[NonAction]
		[ApiExplorerSettings(IgnoreApi = true)]
		private async Task<bool> PersistChangesToDatabase()
		{
			int amountOfChanges = await _appDBContext.SaveChangesAsync();

			return amountOfChanges > 0;
		}

		[NonAction]
		[ApiExplorerSettings(IgnoreApi = true)]
		private async Task<Category> GetCategoryByCategoryId(int categoryId, bool withPosts)
		{
			Category categoryToGet = null;

			if (withPosts)
			{
				categoryToGet = await _appDBContext.Categories.Include(category => category.Posts).FirstOrDefaultAsync(category => category.CategoryId == categoryId);
			}
			else
			{
				categoryToGet = await _appDBContext.Categories.FirstOrDefaultAsync(category => category.CategoryId == categoryId);
			}

			return categoryToGet;
		}
		#endregion
	}
}
