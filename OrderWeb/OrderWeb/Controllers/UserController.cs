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
    public class UserController : ControllerBase
    {
        private readonly UserSvc _svc;
        public UserController()
        {
            _svc = new UserSvc();
        }
        [HttpPost("create-user")]
        public IActionResult CreateUser([FromBody]UserReq req)
        {
            var res = _svc.CreateUser(req);
            return Ok(res);
        }
        [HttpPost("update-user")]
        public IActionResult UpdateUser([FromBody]UserReq req)
        {
            var res = _svc.UpdateUser(req);
            return Ok(res);
        }
        [HttpPost("search-user")]
        public IActionResult SearchUser([FromBody]SearchReq req)
        {
            var res = _svc.SearchUser(req.size, req.page, req.keyWord);
            return Ok(res);
        }
        [HttpPost("delete-user")]
        public IActionResult DeleteUser(String userId)
        {
            var res = _svc.DeleteUser(userId);
            return Ok(res);
        }

    [HttpPost("login-user")]
    public IActionResult Login(LoginReq req)
    {
      var res = _svc.Login(req);
      return Ok(res);
    }
  }
}
