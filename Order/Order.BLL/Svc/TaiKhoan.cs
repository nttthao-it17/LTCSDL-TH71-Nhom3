using LTCSDL.Common.BLL;
using LTCSDL.Common.Rsp;
using Order.Common.Req;
using Order.DAL.Models;
using Order.DAL.Rep;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.BLL.Svc
{
    public class TaiKhoan : GenericSvc<DAL.Rep.TaiKhoan, DAL.Models.TaiKhoan>
    {
        //Sử dụng hàm tạo
        public SingleRsp CreateUser(TaiKhoanReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo user
            DAL.Models.TaiKhoan taiKhoan = new DAL.Models.TaiKhoan();
            //Gán giá trị
            taiKhoan.MaTk = req.MaTK;
            taiKhoan.TenTk = req.TenTK;
            taiKhoan.MatKhau = req.MatKhau;
            taiKhoan.LoaiTk = req.LoaiTK;
           
            taiKhoan.GhiChu = req.GhiChu;
            //Tạo sau khi gán giá trị
            res = base.Create(taiKhoan);
            res.Data = taiKhoan;
            return res;
        }
    }
}
