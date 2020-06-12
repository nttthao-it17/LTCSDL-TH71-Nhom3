using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThucAn
    {
        public ThucAn()
        {
            ThongTinHoaDon = new HashSet<ThongTin_HoaDon>();
        }

        public string MaThucAn { get; set; }
        public string MaLoai { get; set; }
        public string TenThucAn { get; set; }
        public int Gia { get; set; }
        public double? GiamGia { get; set; }
        public string GhiChu { get; set; }

        public virtual LoaiThucAn MaLoaiNavigation { get; set; }
        public virtual ICollection<ThongTin_HoaDon> ThongTinHoaDon { get; set; }
    }
}
