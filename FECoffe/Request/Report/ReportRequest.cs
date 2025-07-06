using Data.DTO.Report;
using FECoffe.DTO.Report;
using System.Net.Http;
using System.Net.Http.Json;

namespace FECoffe.Request.Report
{
    public class ReportRequest
    {
        public static ReportViewModel GetByToDay()
        {
            try
            {
                string url = @"http://localhost:5178/api/Report/GetReport_For_ToDay";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<ReportViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static ReportViewModel GetByToMonth()
        {
            try
            {
                string url = @"http://localhost:5178/api/Report/GetReport_For_Month";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<ReportViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static ReportViewModel GetByDate(DateTime start,DateTime end)
        {
            try
            {
                string url = @"http://localhost:5178/api/Report/GetReport_For_Date?start=" + start +"&end=" + end;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<ReportViewModel>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<IngredientsReport> GetByDateGetReportForIngredients(DateTime start, DateTime end)
        {
            try
            {
                string url = @"http://localhost:5178/api/Report/GetReport_For_Ingredients?start=" + start + "&end=" + end;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<IngredientsReport>>(url);
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
