using Shared.Models.CustomValidations;
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
		[NoPeriods(ErrorMessage = "The category Name field contains one or more period characters. Please remove them")]
		[NoThreeOrMoreSpacesInARow(ErrorMessage = "Category name field has three or more spaces in a row, please fix it.")]
		public string Name { get; set; }

		[Required]
		[MaxLength(1024)] // words
		public string Description { get; set; }


		public List<Post> Posts { get; set; }
	}
}
