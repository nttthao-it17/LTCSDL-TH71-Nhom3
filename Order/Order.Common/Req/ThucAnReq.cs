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
        public int Gia { get; set; }
        public float? GiamGia { get; set; }
        public string GhiChu { get; set; }

    }
}
