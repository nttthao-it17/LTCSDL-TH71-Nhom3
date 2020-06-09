using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThucAn
    {
        public ThucAn()
        {
            Order = new HashSet<Order>();
        }

        public string MaThucAn { get; set; }
        public string MaLoai { get; set; }
        public string TenThucAn { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiamGia { get; set; }

        public virtual LoaiThucAn MaLoaiNavigation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
