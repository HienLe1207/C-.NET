using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        private static List<NhaCungCap> danhSachNhaCungCap = new List<NhaCungCap>();

        [HttpGet("getAll")]
        public List<NhaCungCap> GetAllNhaCungCaps()
        {
            return danhSachNhaCungCap;
        }

        [HttpPost("save")]
        public NhaCungCap SaveNhaCungCap([FromBody] NhaCungCap nhaCungCap)
        {
            nhaCungCap.Id = Guid.NewGuid().ToString(); // Tạo ID mới
            danhSachNhaCungCap.Add(nhaCungCap);
            return nhaCungCap;
        }

        [HttpPut("edit/{id}")]
        public NhaCungCap UpdateNhaCungCap([FromBody] NhaCungCap nhaCungCap, string id)
        {
            var existingNhaCungCap = danhSachNhaCungCap.Find(ncc => ncc.Id == id);
            if (existingNhaCungCap != null)
            {
                existingNhaCungCap.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                // Cập nhật các trường khác
                return existingNhaCungCap;
            }
            throw new Exception($"NhaCungCap not found with id: {id}");
        }

        [HttpDelete("delete/{id}")]
        public void DeleteNhaCungCap(string id)
        {
            var nhaCungCapToRemove = danhSachNhaCungCap.Find(ncc => ncc.Id == id);
            if (nhaCungCapToRemove != null)
            {
                danhSachNhaCungCap.Remove(nhaCungCapToRemove);
            }
            else
            {
                throw new Exception($"NhaCungCap not found with id: {id}");
            }
        }

        [HttpGet("search/{id}")]
        public NhaCungCap GetNhaCungCap(string id)
        {
            var nhaCungCap = danhSachNhaCungCap.Find(ncc => ncc.Id == id);
            if (nhaCungCap != null)
            {
                return nhaCungCap;
            }
            throw new Exception($"NhaCungCap not found with id: {id}");
        }
    }
}
