namespace FECoffe.DTO.Employee
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PositionID { get; set; }
        public bool EmploymentType { get; set; }
        public string PositionName { get; set; }
        public DateOnly StartDate { get; set; }
        public decimal SalaryBase { get; set; }
        public bool Status { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly UpdatedAt { get; set; }
        public string TypeName
        {
            get
            {
                if (EmploymentType == null)
                {
                    return string.Empty;
                }
                else if(EmploymentType == true)
                {
                    return "FullTime";
                }
                else
                {
                    return "PartTime";
                }
            }
        }
        public string GioiTinh
        {
            get
            {
                if(Gender == null)
                {
                    return string.Empty;
                }
                else if (Gender == true)
                {
                    return "Nam";
                }
                else
                {
                    return "Nữ";
                }
            }
        }
        public string StatusVN
        {
            get
            {
                if (Status == true) return "Đang làm";
                else if (Status == false) return "Đã nghĩ làm";
                else return string.Empty;
            }
        }
    }
}
