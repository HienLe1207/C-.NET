using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Phonestore.Models
{
    public class KhachHang
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public KhachHang()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Ten = string.Empty;
            Sdt = string.Empty;
            GioiTinh = string.Empty;
            DiaChi = string.Empty;
        }
    }
}
