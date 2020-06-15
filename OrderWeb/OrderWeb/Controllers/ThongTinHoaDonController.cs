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
    public class ThongTinHoaDonController : ControllerBase
    {
      private readonly ThongTinHoaDonSvc _svc;
      public ThongTinHoaDonController()
      {
        _svc = new ThongTinHoaDonSvc();
      }
      [HttpPost("create-thongTinHoaDon")]
      public IActionResult CreateThongTinHoaDon([FromBody]ThongTinHoaDonReq req)
      {
        var res = _svc.CreateThongTinHoaDon(req);
        return Ok(res);
      }
    //Update
    [HttpPost("update-thongTinHoaDon")]
    public IActionResult UpdateThongTinHoaDon([FromBody]ThongTinHoaDonReq req)
    {
      var res = _svc.UpdateThongtinHoaDon(req);
      return Ok(res);
    }
    [HttpPost("search-thongTinHoaDon")]
      public IActionResult SearchThongTinHoaDon([FromBody]SearchReq req)
      {
        var res = _svc.SearchThongTinHoaDon(req.size, req.page, req.keyWord);
        return Ok(res);
      }
      //Delete
      [HttpPost("delete-thongTinHoaDon")]
      public IActionResult DeleteOrder(String maOrder)
      {
        var res = _svc.DeleteThongTinHoaDon(maOrder);
        return Ok(res);
      }
  }
}
