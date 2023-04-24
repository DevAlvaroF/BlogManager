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

		private readonly IWebHostEnvironment _webHostEnvironment;

		public CategoriesController(AppDBContext appDBContext, IWebHostEnvironment webHostEnvironment)
		{
			_appDBContext = appDBContext;
			_webHostEnvironment = webHostEnvironment;
		}
		#region Get Methods


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
		#endregion

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

		#region Post Methods

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Category categoryToCreate)
		{
			try
			{
				if (categoryToCreate == null)
				{
					return BadRequest(ModelState);

				}
				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				await _appDBContext.Categories.AddAsync(categoryToCreate);

				bool changersPersistedToDatabase = await PersistChangesToDatabase();

				if (changersPersistedToDatabase == false)
				{
					return StatusCode(500, $"Something went wrong on our side. Please contact the admin.");
				}

				return Created("Create", categoryToCreate);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Something went wrong on our side. Please contact the admin and show him this\n{ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] Category categoryToUpdate)
		{
			try
			{
				if (id < 1 || id != categoryToUpdate.CategoryId || categoryToUpdate == null)
				{
					return BadRequest(ModelState);
				}

				bool exists = await _appDBContext.Categories.AnyAsync(category => category.CategoryId == id);

				if (exists == false)
				{
					return NotFound();
				}

				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				_appDBContext.Categories.Update(categoryToUpdate);

				bool changersPersistedToDatabase = await PersistChangesToDatabase();

				if (changersPersistedToDatabase == false)
				{
					return StatusCode(500, $"Something went wrong on our side. Please contact the admin.");
				}

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Something went wrong on our side. Please contact the admin and show him this\n{ex.Message}");
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				if (id < 1)
				{
					return BadRequest(ModelState);
				}

				bool exists = await _appDBContext.Categories.AnyAsync(category => category.CategoryId == id);

				if (exists == false)
				{
					return NotFound();
				}

				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				Category categoryToDelete = await GetCategoryByCategoryId(id, false);

				if (categoryToDelete.ThumbnailImagePath != "uploads/placeholder.jpg")
				{
					string fileName = categoryToDelete.ThumbnailImagePath.Split("/").Last();

					System.IO.File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwrooot\\uploads\\{fileName}");
				}

				_appDBContext.Categories.Remove(categoryToDelete);

				bool changersPersistedToDatabase = await PersistChangesToDatabase();

				if (changersPersistedToDatabase == false)
				{
					return StatusCode(500, $"Something went wrong on our side. Please contact the admin.");
				}

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Something went wrong on our side. Please contact the admin and show him this\n{ex.Message}");
			}
		}

		#endregion
	}
}
