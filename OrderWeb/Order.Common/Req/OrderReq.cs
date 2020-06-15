using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
    public class OrderReq
    {
        public string MaOrder { get; set; }
        public DateTime? NgayDatMon { get; set; }
        public string MaNguoiDung { get; set; }
    }
}
