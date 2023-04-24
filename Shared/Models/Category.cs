using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
	public class Category
	{
		[Key]
		[Required]
		public int CategoryId { get; set; }

		[Required]
		[MaxLength(256)] // words
		public string ThumbnailImagePath { get; set; }

		[Required]
		[MaxLength(128)] // words
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)] // words
		public string Description { get; set; }


		public List<Post> Posts { get; set; }
	}
}
