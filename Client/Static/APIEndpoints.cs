namespace Client.Static
{
	internal static class APIEndpoints
	{
#if DEBUG

		public const string ServerBaseUrl = "https://localhost:5003";
#else
		public const string ServerBaseUrl = "https://appname.azurewensites.net";
#endif
		internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
		internal readonly static string s_imageUpload = $"{ServerBaseUrl}/api/imageupload";
	}
}
