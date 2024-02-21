using Microsoft.AspNetCore.Mvc;
using Phonestore.Models;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private static List<Order> _orders = new List<Order>();

    [HttpPost("save")]
    public ActionResult<Order> SubmitOrder([FromBody] Order order)
    {
        // Thêm thời gian hiện tại khi tạo đối tượng Order
        order.ThoiGianDatHang = DateTime.Now;
        SaveOrder(order);
        return Ok(order);
    }

    [HttpGet("getAll")]
    public ActionResult<List<Order>> GetAllOrders()
    {
        var orders = ListAll();
        return Ok(orders);
    }

    private static void SaveOrder(Order order)
    {
        _orders.Add(order);
    }

    private static List<Order> ListAll()
    {
        return _orders;
    }
}
