using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class Order
    {
        public string MaOrder { get; set; }
        public string MaThucAn { get; set; }
        public string TenThucAn { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiamGia { get; set; }

        public virtual ThucAn MaThucAnNavigation { get; set; }
    }
}
