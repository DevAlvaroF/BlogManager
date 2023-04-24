using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly AppDBContext _appDBContext;

		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly IMapper _mapper;
		public PostsController(AppDBContext appDBContext, IWebHostEnvironment webHostEnvironment, IMapper mapper)
		{
			_appDBContext = appDBContext;
			_mapper = mapper;
			_webHostEnvironment = webHostEnvironment;
		}
		#region Get Methods


		[HttpGet]
		public async Task<IActionResult> Get()
		{
			// Return Posts from database
			List<Post> Posts = await _appDBContext.Posts.Include(post => post.Category).ToListAsync();

			return Ok(Posts);
		}

		[HttpGet("dto/{id}")]
		public async Task<IActionResult> GetDTO(int id)
		{
			Post post = await GetPostByPostId(id);
			PostDTO postDTO = _mapper.Map<PostDTO>(post);

			return Ok(postDTO);
		}


		[HttpGet("{id}")] // website.com/api/Posts/3
		public async Task<IActionResult> Get(int id)
		{
			Post Post = await GetPostByPostId(id);

			return Ok(Post);
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
		private async Task<Post> GetPostByPostId(int PostId)
		{
			Post PostToGet = await _appDBContext.Posts.Include(Post => Post.Category).FirstOrDefaultAsync(Post => Post.PostId == PostId);

			return PostToGet;
		}
		#endregion

		#region Post Methods

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] PostDTO PostToCreateDTO)
		{
			try
			{
				if (PostToCreateDTO == null)
				{
					return BadRequest(ModelState);

				}
				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				Post PostToCreate = _mapper.Map<Post>(PostToCreateDTO);

				if (PostToCreate.Published == true)
				{
					// Add european date time
					PostToCreate.PublishDate = DateTime.UtcNow.ToString("dd/MM/yyy hh:mm");
				}

				await _appDBContext.Posts.AddAsync(PostToCreate);

				bool changersPersistedToDatabase = await PersistChangesToDatabase();

				if (changersPersistedToDatabase == false)
				{
					return StatusCode(500, $"Something went wrong on our side. Please contact the admin.");
				}

				return Created("Create", PostToCreate);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Something went wrong on our side. Please contact the admin and show him this\n{ex.Message}");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] PostDTO PostToUpdateDTO)
		{
			try
			{
				if (id < 1 || id != PostToUpdateDTO.PostId || PostToUpdateDTO == null)
				{
					return BadRequest(ModelState);
				}

				Post? oldPost = await _appDBContext.Posts.FindAsync(id);

				if (oldPost == null)
				{
					return NotFound();
				}
				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				Post PostToUpdate = _mapper.Map<Post>(PostToUpdateDTO);

				if (PostToUpdate.Published == true)
				{
					if (oldPost.Published)
					{

						PostToUpdate.PublishDate = DateTime.UtcNow.ToString("dd/MM/yyy hh:mm");
					}
					else
					{
						PostToUpdate.PublishDate = oldPost.PublishDate;
					}

				}
				else
				{
					PostToUpdate.PublishDate = string.Empty;
				}

				// Detach oldPost from EF, else if can't be updated
				_appDBContext.Entry(oldPost).State = EntityState.Detached;

				_appDBContext.Posts.Update(PostToUpdate);

				bool changersPersistedToDatabase = await PersistChangesToDatabase();

				if (changersPersistedToDatabase == false)
				{
					return StatusCode(500, $"Something went wrong on our side. Please contact the admin.");
				}

				return Created("Create", PostToUpdate);
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

				bool exists = await _appDBContext.Posts.AnyAsync(Post => Post.PostId == id);

				if (exists == false)
				{
					return NotFound();
				}

				if (ModelState.IsValid == false)
				{
					return BadRequest(ModelState);
				}

				Post PostToDelete = await GetPostByPostId(id);

				if (PostToDelete.ThumbnailImagePath != "uploads/placeholder.jpg")
				{
					string fileName = PostToDelete.ThumbnailImagePath.Split("/").Last();

					System.IO.File.Delete($"{_webHostEnvironment.ContentRootPath}\\wwwrooot\\uploads\\{fileName}");
				}

				_appDBContext.Posts.Remove(PostToDelete);

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
