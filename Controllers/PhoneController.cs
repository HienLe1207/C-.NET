using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private static List<Phone> _phones = new List<Phone>();

        [HttpGet("getAllPhone")]
        public ActionResult<List<Phone>> GetPhones()
        {
            return _phones;
        }

        [HttpPost("save")]
        public ActionResult<string> SavePhone([FromBody] Phone phone)
        {
            // Khởi tạo thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Gán thời gian hiện tại vào thuộc tính PurchaseTime
            phone.ThoiGianMuaHang = currentTime;

            // Lưu vào cơ sở dữ liệu
            _phones.Add(phone);

            return Ok(phone.Id);
        }

        [HttpPut("edit/{id}")]
        public ActionResult<Phone> UpdatePhone([FromBody] Phone updatedPhone, string id)
        {
            // Lấy ra đối tượng cần cập nhật từ cơ sở dữ liệu
            var existingPhone = _phones.Find(p => p.Id == id);

            // Kiểm tra nếu đối tượng tồn tại
            if (existingPhone != null)
            {
                // Cập nhật các trường, trừ trường thời gian
                existingPhone.TenĐT = updatedPhone.TenĐT;
                existingPhone.Loai = updatedPhone.Loai;
                existingPhone.MauSac = updatedPhone.MauSac;
                existingPhone.Ncc = updatedPhone.Ncc;
                existingPhone.Gia = updatedPhone.Gia;
            }

            return Ok(existingPhone);

        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeletePhone(string id)
        {
            var phoneToRemove = _phones.Find(p => p.Id == id);
            if (phoneToRemove != null)
            {
                _phones.Remove(phoneToRemove);
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("search/{id}")]
        public ActionResult<Phone> GetPhone(string id)
        {
            var phone = _phones.Find(p => p.Id == id);
            if (phone != null)
            {
                return Ok(phone);
            }
            return NotFound();
        }

        [HttpGet("searchByName/{name}")]
        public ActionResult<List<Phone>> SearchPhones(string name)
        {
            var phones = _phones.FindAll(p => p.TenĐT.Contains(name));
            return Ok(phones);
        }

    }
}
