namespace FECoffe.DTO.Salaries
{
    public class CrudSalaries
    {
        public int EmployeeID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public float TotalWorkingHours { get; set; }
        public decimal Bonus { get; set; }
        public decimal Penalty { get; set; }
        public decimal FinalSalary { get; set; }
        public DateOnly CreatedAt { get; set; }
        public Guid UserID { get; set; }
    }
}
