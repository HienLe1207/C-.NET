using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCCController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public NCCController(IConfiguration configguration)
        {
            _configuration = configguration;
        }

        [HttpGet]
        public JsonResult GetAllNCC()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var dbList = dbClient.GetDatabase("phonestore").GetCollection<NhaCungCap>("NCC").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpPost]
        public JsonResult Post(NhaCungCap ncc)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            int LastMaNcc = dbClient.GetDatabase("phonestore").GetCollection<NhaCungCap>("NCC").AsQueryable().Count();
            ncc.MaNCC = LastMaNcc + 1;
            dbClient.GetDatabase("phonestore").GetCollection<NhaCungCap>("NCC").InsertOne(ncc);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(NhaCungCap updateNcc)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter=Builders<NhaCungCap>.Filter.Eq("MaNcc", updateNcc.MaNCC);
            var updateDefinition = Builders<NhaCungCap>.Update
             .Set(ncc => ncc.TenNCC, updateNcc.TenNCC)
             .Set(ncc => ncc.Sdt, updateNcc.Sdt)
             .Set(ncc => ncc.DiaChi, updateNcc.DiaChi);
            dbClient.GetDatabase("phonestore").GetCollection<NhaCungCap>("Ncc").UpdateOne(filter,updateDefinition);
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<NhaCungCap>.Filter.Eq("MaNcc", id);
            dbClient.GetDatabase("phonestore").GetCollection<NhaCungCap>("NCC").DeleteOne(filter);
            return new JsonResult("Deleted Successfully");
        }
    }
}
