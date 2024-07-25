using Entity;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace WebUI.Services
{
    public class DataLoaderService(HttpClient httpClient, IMemoryCache memoryCache)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IMemoryCache _memoryCache = memoryCache;

        public async Task<List<SchoolClass>> LoadSchoolClassDataAsync()
        {
            var getResults = await _httpClient.GetFromJsonAsync<ApiResponse<List<SchoolClass>>>("api/SchoolClass/GetAllClass").ConfigureAwait(false);
            if (getResults.Success)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(1));//设置滑动过期时间
                _memoryCache.Set("SchoolClassData", JsonConvert.SerializeObject(getResults.Data), cacheEntryOptions);
                return getResults.Data;
            }
            else
            {
                return new List<SchoolClass>();
            }
        }
    }
}
