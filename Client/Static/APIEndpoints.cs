namespace Client.Static
{
	internal static class APIEndpoints
	{
#if DEBUG

		private const string ServerBaseUrl = "https://localhost:5003";
#else
		private const string ServerBaseUrl = "https://appname.azurewensites.net";
#endif
		internal readonly static string s_categories = $"{ServerBaseUrl}/api/categories";
	}
}
