using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECoffe.DTO.EmployeeSchedules
{
    public class CrudEmployeeSchedules
    {
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateTime WorkDate { get; set; } = DateTime.Now;
        public bool IsWorking { get; set; }
        public string Note { get; set; }
    }
}
