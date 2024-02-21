using MongoDB.Bson;

namespace Phonestore.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string ChucVu { get; set; }
        public string GioiTinh { get; set; }
        public User()
        {
            Id = ObjectId.GenerateNewId().ToString();
            UserName = string.Empty;
            Password = string.Empty;
            Ten = string.Empty;
            DiaChi = string.Empty;
            Sdt = string.Empty;
            ChucVu = string.Empty;
            GioiTinh = string.Empty;
        }
    }
}
