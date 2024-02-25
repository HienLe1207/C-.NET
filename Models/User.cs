using MongoDB.Bson;

namespace Phonestore.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public int MaUser { get; set; }
        public string ChucVu { get; set; }
        public string TenUser { get; set; }
        public string Password { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string GioiTinh { get; set; }
        public User()
        {
            ChucVu = string.Empty;
            TenUser = string.Empty;
            Password = string.Empty;
            DiaChi = string.Empty;
            Sdt = string.Empty;            
            GioiTinh = string.Empty;
        }
    }
}
