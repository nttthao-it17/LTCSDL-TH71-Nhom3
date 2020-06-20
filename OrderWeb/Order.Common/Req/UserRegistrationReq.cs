using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
  public class UserRegistrationReq
  {
    public string TenNguoiDung { get; set; }
    public string Email { get; set; }
    public string MatKhau { get; set; }
    public string DiaChi { get; set; }
    public string SoDienThoai { get; set; }
  }
}
