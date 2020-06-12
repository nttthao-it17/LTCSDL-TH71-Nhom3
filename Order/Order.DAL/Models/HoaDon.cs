using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ThongTinHoaDon = new HashSet<ThongTin_HoaDon>();
        }

        public string MaHoaDon { get; set; }
        public string MaNguoiMua { get; set; }
        public string MaNguoiTao { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime? ThoiGianIn { get; set; }
        public string GhiChu { get; set; }

        public virtual ThongTin_TaiKhoan MaNguoiMuaNavigation { get; set; }
        public virtual ThongTin_TaiKhoan MaNguoiTaoNavigation { get; set; }
        public virtual ICollection<ThongTin_HoaDon> ThongTinHoaDon { get; set; }
    }
}
