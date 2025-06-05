namespace FECoffe.DTO.Shifts
{
    public class CrudShifts
    {
        public string ShiftName { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Description{ get; set; }
    }
}
