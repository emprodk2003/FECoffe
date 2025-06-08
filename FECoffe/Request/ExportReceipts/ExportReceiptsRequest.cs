using FECoffe.DTO.ExportDetail;
using FECoffe.DTO.ExportReceipts;
using FECoffe.DTO.ImportDetail;
using FECoffe.DTO.ImportReceipts;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.ExportReceipts
{
    public class ExportReceiptsRequest
    {
        public static bool createExport(CreateExportDTO data)
        {
            try
            {
                string url = @"http://localhost:5178/api/ExportReceipts";
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

        public static List<CrudExportReceipts> GetExportReceipts()
        {
            try
            {
                string url = @"http://localhost:5178/api/ExportReceipts/GetAllExport";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudExportReceipts>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<ExportDetail> GetExportDetailByReceipID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ExportDetails/GetExportDetailByReceipID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<ExportDetail>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static CrudExportReceipts GetExportReceiptsById(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/ExportReceipts/GetExportReceiptsByID?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<CrudExportReceipts>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudExportReceipts> GetExportReceiptsByDay(DateTime fromDay, DateTime toDay)
        {
            try
            {
                string url = @"http://localhost:5178/api/ExportReceipts/GetExportReceiptsByDay?fromDay=" + fromDay + "&toDay=" + toDay;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudExportReceipts>>(url);
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
