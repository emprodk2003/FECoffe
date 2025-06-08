using FECoffe.DTO.LotDetails;
using FECoffe.DTO.Lots;
using FECoffe.DTO.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FECoffe.Request.Lots
{
    public class LotsRequest
    {
        public static List<CrudLot> GetLotByMaterialID(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetByLot?id=" + id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudLot>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudLot> GetLots()
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetAllLot";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudLot>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudLotDetails> GetLotDetails()
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetAllLotDetail";
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudLotDetails>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static CrudLot GetLotById(int id)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetLotById?id="+id;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<CrudLot>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }

        public static List<CrudLotDetails> GetLotDetailsByDay(DateTime fromDay, DateTime toDay)
        {
            try
            {
                string url = @"http://localhost:5178/api/Materials/GetLotDetailsByDay?fromDay="+fromDay+ "&toDay="+toDay;
                HttpClient client = new HttpClient();
                var res = client.GetFromJsonAsync<List<CrudLotDetails>>(url);
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
