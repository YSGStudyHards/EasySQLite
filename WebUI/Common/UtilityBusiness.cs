namespace WebUI.Common
{
    public class UtilityBusiness
    {
        public static bool CheckResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
