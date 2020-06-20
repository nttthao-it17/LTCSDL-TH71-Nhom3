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
    public class ThucAnController : ControllerBase
    {
        private readonly ThucAnSvc _svc;
        public ThucAnController()
        {
            _svc = new ThucAnSvc();
        }
        [HttpPost("create-thucAn")]
        public IActionResult CreateThucAn([FromBody]ThucAnReq req)
        {
            var res = _svc.CreateThucAn(req);
            return Ok(res);
        }
        [HttpPost("update-thucAn")]
        public IActionResult UpdateThucAn([FromBody]ThucAnReq req)
        {
            var res = _svc.UpdateThucAn(req);
            return Ok(res);
        }
        [HttpPost("search-thuc")]
        public IActionResult SearchThucAn([FromBody]SearchReq req)
        {
            var res = _svc.SearchThucAn(req.size, req.page, req.keyWord);
            return Ok(res);
        }
        [HttpPost("delete-thucAn")]
        public IActionResult DeleteThucAn(String maThucAn)
        {
            var res = _svc.DeleteThucAn(maThucAn  );
            return Ok(res);
        }
    }
}
