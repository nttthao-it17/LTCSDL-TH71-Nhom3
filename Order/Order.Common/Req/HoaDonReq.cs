using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
    public class HoaDonReq
    {
        public string MaHoaDon { get; set; }
        public string MaNguoiMua { get; set; }
        public string MaNguoiTao { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime ThoiGianIn { get; set; }
        public string GhiChu { get; set; }
    }
}
