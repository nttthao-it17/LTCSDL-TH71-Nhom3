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
    public class LoaiThucAnController : ControllerBase
    {
        private readonly LoaiThucAnSvc _svc;
        public LoaiThucAnController()
        {
            _svc = new LoaiThucAnSvc();
        }
        [HttpPost("create-loaiThucAn")]
        public IActionResult CreateLoaiThucAn([FromBody]LoaiThucAnReq req)
        {
            var res = _svc.CreateLoaiThucAn(req);
            return Ok(res);
        }
        [HttpPost("update-loaiThucAn")]
        public IActionResult UpdateLoaiThucAn([FromBody]LoaiThucAnReq req)
        {
            var res = _svc.UpdateLoaiThucAn(req);
            return Ok(res);
        }
        [HttpPost("search-LoaiThucAn")]
        public IActionResult SearchLoaiThucAn([FromBody]SearchReq req)
        {
            var res = _svc.SearchLoaiThucAn(req.size, req.page, req.keyWord);
            return Ok(res);
        }
        [HttpPost("delete-loaiThucAn")]
        public IActionResult DeleteLoaiThucAn(String maLoaiThucAn)
        {
            var res = _svc.DeleteLoaiThucAn(maLoaiThucAn);
            return Ok(res);
        }
    }
}