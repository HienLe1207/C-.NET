
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Phonestore.Models
{
    public class NhaCungCap
    {
        public ObjectId Id { get; set; }
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }

        public NhaCungCap()
        {
           
            TenNCC = string.Empty;
            Sdt = string.Empty;
            DiaChi = string.Empty;
        }
    }
}

