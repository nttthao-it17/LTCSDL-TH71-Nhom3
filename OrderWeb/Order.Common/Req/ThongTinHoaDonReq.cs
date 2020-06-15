using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
  public class ThongTinHoaDonReq
  {
    public string MaOrder { get; set; }
    public string MaThucAn { get; set; }
    public int? Gia { get; set; }
    public double? GiamGia { get; set; }
    public string GhiChu { get; set; }
  }
}
