using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThucAn
    {
        public ThucAn()
        {
            ThongTinHoaDon = new HashSet<ThongTinHoaDon>();
        }

        public string MaThucAn { get; set; }
        public string MaLoai { get; set; }
        public string TenThucAn { get; set; }
        public int? Gia { get; set; }
        public int? GiamGia { get; set; }
        public string ChiChu { get; set; }

        public virtual LoaiThucAn MaLoaiNavigation { get; set; }
        public virtual ICollection<ThongTinHoaDon> ThongTinHoaDon { get; set; }
    }
}
