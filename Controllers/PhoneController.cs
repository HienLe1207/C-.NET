using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Phone_Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public Phone_Controller(IConfiguration configguration)
        {
            _configuration = configguration;
        }

        [HttpGet]
        public JsonResult GetAllPhone()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var dbList = dbClient.GetDatabase("phonestore").GetCollection<Phone>("Phone").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpPost]
        public JsonResult Post(Phone phone) 
        { 
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            int LastMaPhone = dbClient.GetDatabase("phonestore").GetCollection<Phone>("Phone").AsQueryable().Count();
            phone.MaPhone = LastMaPhone + 1;
            dbClient.GetDatabase("phonestore").GetCollection<Phone>("Phone").InsertOne(phone);
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Phone updatePhone)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<Phone>.Filter.Eq("MaPhone", updatePhone.MaPhone);
            var updateDefinition = Builders<Phone>.Update
             .Set(phone => phone.TenPhone, updatePhone.TenPhone)
             .Set(phone => phone.Loai, updatePhone.Loai)
             .Set(phone => phone.MauSac, updatePhone.MauSac)
             .Set(phone => phone.nhacungcap, updatePhone.nhacungcap);
            dbClient.GetDatabase("phonestore").GetCollection<Phone>("Phone").UpdateOne(filter, updateDefinition);
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<Phone>.Filter.Eq("MaPhone", id);
            dbClient.GetDatabase("phonestore").GetCollection<Phone>("Phone").DeleteOne(filter);
            return new JsonResult("Deleted Successfully");
        }
    }
}
