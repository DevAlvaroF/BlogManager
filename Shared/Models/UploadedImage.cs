namespace Shared.Models
{
	public class UploadedImage
	{
		public string NewImageFileExtension { get; set; }
		// String representing binary
		public string NewImageBase64Content { get; set; }
		public string OldImagePath { get; set; }
	}
}
