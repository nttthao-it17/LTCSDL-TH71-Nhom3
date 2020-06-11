using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
    public class ThucAnReq
    {
        public string MaThucAn { get; set; }
        public string MaLoai { get; set; }
        public string TenThucAn { get; set; }
        public int? Gia { get; set; }
        public int? GiamGia { get; set; }
        public string ChiChu { get; set; }

    }
}
