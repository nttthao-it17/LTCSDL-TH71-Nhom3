using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.BLL.Svc;
using Order.Common.Req;

namespace OrderWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserRegistrationController : ControllerBase
  {
    private readonly UserRegistrationSvc _svc;
    public UserRegistrationController()
    {
      _svc = new UserRegistrationSvc();
    }

    [HttpPost("tao-tai-khoan")]
    public IActionResult AddAccount([FromBody] UserRegistrationReq req)
    {
      var res = _svc.AddAccount(req);
      return Ok(res);
    }
  }
}
