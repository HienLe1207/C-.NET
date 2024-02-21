using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("authenticate")]
        public ActionResult<string> AuthenticateUser([FromBody] User user)
        {
            // Thực hiện logic xác thực người dùng tại đây
            // Ví dụ đơn giản: Nếu tên người dùng là "admin" và mật khẩu là "admin", xác thực thành công
            if (user.UserName == "admin" && user.Password == "admin")
            {
                return Ok("Authentication successful");
            }

            return Unauthorized("Authentication failed");
        }

        [HttpPost("save")]
        public ActionResult<string> SaveUser([FromBody] User user)
        {
            // Thực hiện logic lưu người dùng vào danh sách tại đây
            _users.Add(user);
            return Ok(user.UserName);
        }

        [HttpPut("update/{id}")]
        public ActionResult<User> UpdateUser(string id, [FromBody] User updatedUser)
        {
            var existingUser = _users.Find(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Thực hiện logic cập nhật thông tin người dùng tại đây
            existingUser.UserName = updatedUser.UserName;
            existingUser.Password = updatedUser.Password;

            return Ok(existingUser);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(string id)
        {
            var userToRemove = _users.Find(u => u.Id == id);
            if (userToRemove == null)
            {
                return NotFound();
            }

            _users.Remove(userToRemove);
            return NoContent();
        }
    }
}
