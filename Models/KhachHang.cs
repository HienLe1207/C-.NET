using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Phonestore.Models
{
    public class KhachHang
    {
        public ObjectId Id { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string Sdt { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public KhachHang()
        {
        
            TenKH = string.Empty;
            Sdt = string.Empty;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
        }
    }
}
