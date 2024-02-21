using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IMongoCollection<KhachHang> _khachHangCollection;

        public KhachHangController(IMongoDatabase database)
        {
            _khachHangCollection = database.GetCollection<KhachHang>("khachHangs");
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<KhachHang>>> GetAllKhachHangs()
        {
            var khachHangs = await _khachHangCollection.Find(_ => true).ToListAsync();
            return Ok(khachHangs);
        }

        [HttpPost("save")]
        public async Task<ActionResult<KhachHang>> SaveKhachHang([FromBody] KhachHang khachHang)
        {
            await _khachHangCollection.InsertOneAsync(khachHang);
            return Ok(khachHang);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<KhachHang>> UpdateKhachHang(
            [FromBody] KhachHang khachHang, [FromRoute] string id)
        {
            var filter = Builders<KhachHang>.Filter.Eq("_id", id);
            var result = await _khachHangCollection.ReplaceOneAsync(filter, khachHang);

            if (result.ModifiedCount == 0)
            {
                return NotFound($"KhachHang not found with id: {id}");
            }

            return Ok(khachHang);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteKhachHang([FromRoute] string id)
        {
            var filter = Builders<KhachHang>.Filter.Eq("_id", id);
            var result = await _khachHangCollection.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                return NotFound($"KhachHang not found with id: {id}");
            }

            return NoContent();
        }

        [HttpGet("search/{id}")]
        public async Task<ActionResult<KhachHang>> GetKhachHangById([FromRoute] string id)
        {
            var filter = Builders<KhachHang>.Filter.Eq("_id", id);
            var khachHang = await _khachHangCollection.Find(filter).FirstOrDefaultAsync();

            if (khachHang == null)
            {
                return NotFound($"KhachHang not found with id: {id}");
            }

            return Ok(khachHang);
        }

        [HttpGet("searchBySdt/{sdt}")]
        public async Task<ActionResult<KhachHang>> GetKhachHangBySdt([FromRoute] string sdt)
        {
            var filter = Builders<KhachHang>.Filter.Eq("sdt", sdt);
            var khachHang = await _khachHangCollection.Find(filter).FirstOrDefaultAsync();

            if (khachHang == null)
            {
                return NotFound($"KhachHang not found with SDT: {sdt}");
            }

            return Ok(khachHang);
        }
    }
}
