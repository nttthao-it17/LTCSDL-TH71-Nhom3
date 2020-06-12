using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
  class ThongTin_HoaDonReq
  {
    
    public string MaTTHoaDon { get; set; }
    public string MaHoaDon { get; set; }
    public string MaThucAn { get; set; }
    public int? SoLuong { get; set; }
    public string GhiChu { get; set; }
  }
}
