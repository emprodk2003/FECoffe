using FECoffe.DTO.Banks;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Banks
{
    public class BankRequest
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static Bank _cachedBanks;

        public static async Task<Bank> GetAllBanksCachedAsync()
        {
            if (_cachedBanks != null)
                return _cachedBanks;

            try
            {
                string url = "https://api.vietqr.io/v2/banks";
                _cachedBanks = await _httpClient.GetFromJsonAsync<Bank>(url);
                return _cachedBanks;
            }
            catch
            {
                return null;
            }
        }

    }
}
