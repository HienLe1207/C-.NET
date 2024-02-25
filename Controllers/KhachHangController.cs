using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHang_Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KhachHang_Controller (IConfiguration configguration)
        {
            _configuration= configguration;
        }

        [HttpGet]
        public JsonResult GetAllKhachHangs()
        {
           MongoClient dbClient=new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var dbList = dbClient.GetDatabase("phonestore").GetCollection<KhachHang>("KhachHang").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpPost]
        public JsonResult Post(KhachHang KH)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            int LastMaKH = dbClient.GetDatabase("phonestore").GetCollection<KhachHang>("KhachHang").AsQueryable().Count();
            KH.MaKH= LastMaKH+1;
            dbClient.GetDatabase("phonestore").GetCollection<KhachHang>("KhachHang").InsertOne(KH);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(KhachHang updateKH)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter =Builders<KhachHang>.Filter.Eq("MaKH", updateKH.MaKH);
            var updateDefinition = Builders<KhachHang>.Update
             .Set(kh => kh.TenKH, updateKH.TenKH)
             .Set(kh => kh.Sdt, updateKH.Sdt)
             .Set(kh => kh.GioiTinh, updateKH.GioiTinh)
             .Set(kh => kh.DiaChi, updateKH.DiaChi);
            dbClient.GetDatabase("phonestore").GetCollection<KhachHang>("KhachHang").UpdateOne(filter, updateDefinition);
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<KhachHang>.Filter.Eq("MaKH", id);
            dbClient.GetDatabase("phonestore").GetCollection<KhachHang>("KhachHang").DeleteOne(filter); 
            return new JsonResult("Deleted Successfully");
        }
    }
}
