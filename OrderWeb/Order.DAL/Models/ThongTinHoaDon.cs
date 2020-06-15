using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThongTinHoaDon
    {
        public string MaOrder { get; set; }
        public string MaThucAn { get; set; }
        public int? Gia { get; set; }
        public double? GiamGia { get; set; }
        public string GhiChu { get; set; }

        public virtual Orders MaOrderNavigation { get; set; }
        public virtual ThucAn MaThucAnNavigation { get; set; }
    }
}
