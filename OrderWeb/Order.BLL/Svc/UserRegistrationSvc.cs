using LTCSDL.Common.BLL;
using LTCSDL.Common.Rsp;
using Order.Common.Req;
using Order.DAL.Models;
using Order.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.BLL.Svc
{
  public class UserRegistrationSvc : GenericSvc<UserRegistrationRep, User>
  {
    Random _r = new Random();

    public SingleRsp AddAccount(UserRegistrationReq req)
    {
      string maNd = "nd" + _r.Next(1,1000);
      var res = new SingleRsp();
      User userregis = new User();
      userregis.MaNguoiDung = maNd;
      userregis.TenNguoiDung = req.TenNguoiDung;
      userregis.Email = req.Email;
      userregis.MatKhau = req.MatKhau;
      userregis.MaLoai = "1";
      userregis.DiaChi = req.DiaChi;
      userregis.SoDienThoai = req.SoDienThoai;
      //Tạo sau khi gán giá trị
      res = base.Create(userregis);
      res.Data = userregis;
      return res;
    }
  }
}
