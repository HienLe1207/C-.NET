using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configguration)
        {
            _configuration = configguration;
        }

        [HttpGet]
        public JsonResult GetAllUser()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var dbList = dbClient.GetDatabase("phonestore").GetCollection<User>("User").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpPost]
        public JsonResult Post(User user)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            int LastMaUser = dbClient.GetDatabase("phonestore").GetCollection<User>("User").AsQueryable().Count();
            user.MaUser = LastMaUser + 1;
            dbClient.GetDatabase("phonestore").GetCollection<User>("User").InsertOne(user);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(User updateUser)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<User>.Filter.Eq("MaUser", updateUser.MaUser);
            var updateDefinition = Builders<User>.Update
             .Set(user => user.ChucVu, updateUser.ChucVu)
             .Set(user => user.TenUser, updateUser.TenUser)
             .Set(user => user.Password, updateUser.Password)
             .Set(user => user.DiaChi, updateUser.DiaChi)
             .Set(user => user.Sdt, updateUser.Sdt)
             .Set(user => user.GioiTinh, updateUser.GioiTinh);
            dbClient.GetDatabase("phonestore").GetCollection<User>("User").UpdateOne(filter, updateDefinition);
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<User>.Filter.Eq("MaUser", id);
            dbClient.GetDatabase("phonestore").GetCollection<User>("User").DeleteOne(filter);
            return new JsonResult("Deleted Successfully");
        }
    }
}
