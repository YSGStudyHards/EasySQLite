using Entity;
using System.Text.Json;

namespace WebUI.Common
{
    public class UtilityBusiness
    {
        public static bool CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                var result = JsonSerializer.Deserialize<ApiResponse<int>>(jsonResponse) ?? new ApiResponse<int>();
                return result.Success;
            }
            else
            {
                return false;
            }
        }
    }
}
