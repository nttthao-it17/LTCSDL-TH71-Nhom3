using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
    public class OrderReq
    {
        public string MaOrder { get; set; }
        public string MaThucAn { get; set; }
        public string TenThucAn { get; set; }
        public int? Gia { get; set; }
        public int? GiamGia { get; set; }
        public DateTime? NgayDatMon { get; set; }
        public string MaNguoiDung { get; set; }
    }
}
