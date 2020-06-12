using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThongTin_HoaDon
    {
        public string MaTthoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string MaThucAn { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }

        public virtual HoaDon MaHoaDonNavigation { get; set; }
        public virtual ThucAn MaThucAnNavigation { get; set; }
    }
}
