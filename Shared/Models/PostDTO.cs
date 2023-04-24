using Shared.Models.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
	public class PostDTO
	{
		[Key]
		[Required]
		public int PostId { get; set; }

		[Required]
		[MaxLength(128)]
		[NoPeriods(ErrorMessage = "The post title field contains one or more period characters, please fix it")]
		[NoThreeOrMoreSpacesInARow(ErrorMessage = "The post title field contains three or more spaces in a row, please fix it")]
		public string Title { get; set; }


		[Required]
		[MaxLength(256)] // words
		public string ThumbnailImagePath { get; set; }

		[Required]
		[MaxLength(512)]
		public string Excerpt { get; set; }

		[MaxLength(65536)]
		public string Content { get; set; }

		[Required]
		public bool Published { get; set; }

		[Required]
		[MaxLength(128)]
		public string Author { get; set; }

		[Required]
		public int CategoryId { get; set; }

	}
}
