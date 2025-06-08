using System.ComponentModel.DataAnnotations;

namespace FECoffe.DTO.Topping
{
    public class ToppingViewModel
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Trangthai
        {
            get
            {
                if (IsAvailable == true) return "Dang ban";
                else if (IsAvailable == false) return "Da ngung ban";
                else return string.Empty;
            }
        }
    }
}
