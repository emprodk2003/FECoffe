namespace FECoffe.DTO.Product
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string Category_Name { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string UrlImg { get; set; }
        public string Trangthai
        {
            get
            {
                if(IsAvailable == null) { return string.Empty; }
                else if( IsAvailable == true) { return "Dang ban"; }
                else return "Da ngung ban";
            }
        }
    }
}
