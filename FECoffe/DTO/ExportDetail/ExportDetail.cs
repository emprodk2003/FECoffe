using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECoffe.DTO.ExportDetail
{
   public class ExportDetail
    {
        public int ExportDetailID { get; set; }
        public int ExportID { get; set; }
        public int MaterialID { get; set; }
        public float Quantity { get; set; }
    }
}
