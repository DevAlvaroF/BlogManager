using Client.Static;
using Shared.Models;
using System.Net.Http.Json;

namespace Client.Services
{
	internal sealed class InMemoryDatabaseCache
	{
		private readonly HttpClient _httpClient;

		public InMemoryDatabaseCache(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		private List<Category> _categories = null;
		internal List<Category> Categories
		{
			get
			{
				return _categories;
			}

			set
			{
				_categories = value;
				NotifyCategoriesDataChange();
			}
		}

		internal async Task<Category> GetCategoryByCategoryId(int categoryId)
		{
			if (_categories == null)
			{
				await GetCategoriesFromDatabaseAndCache();
			}

			return _categories.First(category => category.CategoryId == categoryId);
		}

		private bool _gettingCategoriesFromDatabaseAndCahing = false;
		internal async Task GetCategoriesFromDatabaseAndCache()
		{
			// Only allow one Get request at a time
			if (_gettingCategoriesFromDatabaseAndCahing == false)
			{
				_gettingCategoriesFromDatabaseAndCahing = true;
				Categories = await _httpClient.GetFromJsonAsync<List<Category>>(APIEndpoints.s_categories);
				_gettingCategoriesFromDatabaseAndCahing = false;
			}
		}

		internal event Action OnCategoriesDataChanged;
		// Notify components when data has changed
		private void NotifyCategoriesDataChange() => OnCategoriesDataChanged?.Invoke();

	}
}
