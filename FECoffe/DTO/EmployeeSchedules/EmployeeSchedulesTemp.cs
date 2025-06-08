namespace FECoffe.DTO.EmployeeSchedules
{
    public class EmployeeSchedulesTemp
    {
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateOnly WorkDate { get; set; }
        public bool IsWorking { get; set; }
        public string Note { get; set; }
    }
}
