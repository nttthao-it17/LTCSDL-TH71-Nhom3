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
  public class GetOrdersListController : ControllerBase
  {
    public GetOrdersListController()
    {
      _svc = new GetOrdersListSvc();
    }
    private readonly GetOrdersListSvc _svc;

    [HttpPost("lay-danh-sach-don-hang-theo-ngay")]
    public IActionResult GetDanhSachDonHang([FromBody] GetOrdersListReq req)
    {
      var res = new SingleRsp();
      var hist = _svc.GetDanhSachDonHang(req.dateFrom, req.dateTo, req.Size, req.Page);
      res.Data = hist;
      return Ok(res);
    }
  }
}
