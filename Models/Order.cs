using MongoDB.Bson;

namespace Phonestore.Models
{
    public class Order
    {
        public ObjectId Id { get; set; }
        public int MaDonHang { get; set; }
        public string TenKH { get; set; }
        public string TenNhanVienBanHang { get; set; }
        public string DiaChi { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public int Price { get; set; }
        public DateTime ThoiGianDatHang { get; set; }
        public Order()
        {
            
            TenKH = string.Empty;
            TenNhanVienBanHang = string.Empty;
            DiaChi = string.Empty;
            PhuongThucThanhToan = string.Empty;
            ThoiGianDatHang = DateTime.Now;
            
        }
    }
}
