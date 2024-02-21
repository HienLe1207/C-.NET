
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Phonestore.Models
{
    public class NhaCungCap
    {
        public string Id { get; set; }
        public string TenNhaCungCap { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }

        public NhaCungCap()
        {
            Id = ObjectId.GenerateNewId().ToString();
            TenNhaCungCap = string.Empty;
            Sdt = string.Empty;
            DiaChi = string.Empty;
        }
    }
}

