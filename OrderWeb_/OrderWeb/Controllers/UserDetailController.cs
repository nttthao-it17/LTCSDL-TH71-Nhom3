using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.BLL.Svc;
using Order.Common.Req;

namespace OrderWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UserDetailSvc _svc;
        public UserDetailController()
        {
            _svc = new UserDetailSvc();
        }

        [HttpPost("create-userDetail")]
        public IActionResult CreateUser([FromBody]UserDetailReq req)
        {
            var res = _svc.CreateUser(req);
            return Ok(res);
        }
    }
}