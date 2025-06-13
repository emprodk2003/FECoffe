using FECoffe.DTO.Banks;
using FECoffe.DTO.Categories_Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
