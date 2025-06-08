using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECoffe.DTO.Timekeeping
{
    public class CrudTimekeeping
    {
        public int EmployeeID { get; set; }
        public DateOnly WorkDate { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public float WorkingHours { get; set; }
        public string Note { get; set; }
    }
}
