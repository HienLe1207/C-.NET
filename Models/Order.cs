using MongoDB.Bson;

namespace Phonestore.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string TenKhach { get; set; }
        public string NhanVienBanHang { get; set; }
        public string DiaChi { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DateTime ThoiGianDatHang { get; set; }
        public Order()
        {
            Id = ObjectId.GenerateNewId().ToString();
            TenKhach = string.Empty;
            NhanVienBanHang = string.Empty;
            DiaChi = string.Empty;
            PhuongThucThanhToan = string.Empty;
            ThoiGianDatHang = DateTime.Now;
            
        }
    }
}
