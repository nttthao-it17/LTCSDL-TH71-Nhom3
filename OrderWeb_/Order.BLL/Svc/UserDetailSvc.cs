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
    public class UserDetailSvc : GenericSvc<UserDetailRep, UserDetail>
    {
        //Sử dụng hàm tạo
        public SingleRsp CreateUser(UserDetailReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo user
            UserDetail userDetail = new UserDetail();
            //Gán giá trị
            userDetail.MaLoaiLogin = req.MaLoaiLogin;
            userDetail.MaNguoiDung = req.MaNguoiDung;
            userDetail.DiaChi = req.DiaChi;
            userDetail.Sdt = req.Sdt;
           
            userDetail.GhiChu = req.GhiChu;
            //Tạo sau khi gán giá trị
            res = base.Create(userDetail);
            res.Data = userDetail;
            return res;
        }
    }
}
