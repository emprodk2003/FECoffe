using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.ImportReceipts;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.ImportReceipts
{
    public class ImportReceiptsRequest
    {
        public static bool createImport(CreateImportDTO data)
        {
            try
            {
                string url = @"http://localhost:5178/api/ImportReceipts";
                HttpClient client = new HttpClient();
                var res = client.PostAsJsonAsync(url, data);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        public static List<CrudImportReceipts> GetImportReceipts()
        {
            try
            {
                string url = @"http://localhost:5178/api/ImportReceipts/GetAllImport";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudImportReceipts>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudImportDetail> GetImportDetailByReceipID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ImportDetails/GetImportDetailByReceipID?id="+id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudImportDetail>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static CrudImportReceipts GetImportReceiptsById(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ImportReceipts/GetImportReceiptsById?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<CrudImportReceipts>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudImportReceipts> GetImportReceiptsByDay(DateTime fromDay,DateTime toDay)
        {
            try
            {
                string url = @"http://localhost:5178/api/ImportReceipts/GetImportReceiptsByDay?fromDay=" + fromDay+ "&toDay="+toDay;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudImportReceipts>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
    }
}
