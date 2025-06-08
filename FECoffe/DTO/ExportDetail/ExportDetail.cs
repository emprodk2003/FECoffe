using System.ComponentModel;

namespace FECoffe.DTO.ExportDetail
{
   public class ExportDetail : INotifyPropertyChanged
    {
        public int ExportDetailID { get; set; }
        public int ExportID { get; set; }
        private int _LotID;
        public int LotID { get=> _LotID; set
            {
                if (_LotID != value)
                {
                    _LotID = value;
                    OnPropertyChanged(nameof(_LotID));
                }
            }
        }
        private float _Quantity { get; set; }
        public float Quantity { get=> _Quantity; set
            {
                if (_Quantity != value)
                {
                    _Quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        private DateOnly? _ExpirationDate {  get; set; }
        public DateOnly? ExpirationDate { get=>_ExpirationDate; set
            {
                if (_ExpirationDate != value)
                {
                    _ExpirationDate = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
