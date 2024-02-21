using MongoDB.Bson;

namespace Phonestore.Models
{
    public class Phone
    {
        public string Id { get; set; }
        public string TenĐT { get; set; }
        public string Loai { get; set; }
        public string MauSac { get; set; }
        public NhaCungCap Ncc { get; set; }
        public long Gia { get; set; }
        public DateTime ThoiGianMuaHang { get; set; }
        public Phone()
        {
            Id = ObjectId.GenerateNewId().ToString();
            TenĐT = string.Empty;
            Loai = string.Empty;
            MauSac= string.Empty;
            Ncc = new NhaCungCap();
            Gia = 0;
            ThoiGianMuaHang = DateTime.Now;

        }
    }
}
