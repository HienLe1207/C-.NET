using MongoDB.Bson;

namespace Phonestore.Models
{
    public class Phone
    {
        public ObjectId Id { get; set; }
        public int MaPhone { get; set; }
        public string TenPhone { get; set; }
        public string Loai { get; set; }
        public string MauSac { get; set; }
        public NhaCungCap nhacungcap { get; set; }
        public long Price { get; set; }
        public DateTime ThoiGianMuaHang { get; set; }
        public Phone()
        {
           
            TenPhone = string.Empty;
            Loai = string.Empty;
            MauSac= string.Empty;
            nhacungcap = new NhaCungCap();
            ThoiGianMuaHang = DateTime.Now;

        }
    }
}
