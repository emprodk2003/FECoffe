using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECoffe.DTO.Employee
{
    public class CrudEmployee
    {
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool EmploymentType { get; set; }
        public int PositionID { get; set; }
        public DateOnly StartDate { get; set; }
        public decimal SalaryBase { get; set; }
        public bool Status { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
    }
}
