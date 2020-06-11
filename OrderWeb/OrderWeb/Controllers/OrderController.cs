using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.BLL.Svc;
using Order.Common.Req;
using Order.DAL.Rep;

namespace OrderWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderSvc _svc;
        public OrderController()
        {
            _svc = new OrderSvc();
        }
        [HttpPost("create-Order")]
        public IActionResult CreateOrder([FromBody]OrderReq req)
        {
            var res = _svc.CreateOrder(req);
            return Ok(res);
        }
        //Update
        [HttpPost("update-order")]
        public IActionResult UpdateOrder([FromBody]OrderReq req)
        {
            var res = _svc.UpdateOrder(req);
            return Ok(res);
        }
        //Delete
        [HttpPost("delete-order")]
        public IActionResult DeleteOrder(String maOrder)
        {
            var res = _svc.DeleteOrder(maOrder);
            return Ok(res);
        }
    }
}