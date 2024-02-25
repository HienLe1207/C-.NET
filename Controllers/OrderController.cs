using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Driver;
using Phonestore.Models;

namespace Phonestore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OrderController(IConfiguration configguration)
        {
            _configuration = configguration;
        }

        [HttpGet]
        public JsonResult GetAllNCC()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var dbList = dbClient.GetDatabase("phonestore").GetCollection<Order>("Order").AsQueryable();
            return new JsonResult(dbList);
        }
        [HttpPost]
        public JsonResult Post(Order order)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            int LastMaDonHang = dbClient.GetDatabase("phonestore").GetCollection<Order>("Order").AsQueryable().Count();
            order.MaDonHang = LastMaDonHang + 1;
            dbClient.GetDatabase("phonestore").GetCollection<Order>("Order").InsertOne(order);
            return new JsonResult("Added Successfully");
        }
        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("PhoneStoreApp"));
            var filter = Builders<Order>.Filter.Eq("MaDonHang", id);
            dbClient.GetDatabase("phonestore").GetCollection<Order>("Order").DeleteOne(filter);
            return new JsonResult("Deleted Successfully");
        }
    }
}
