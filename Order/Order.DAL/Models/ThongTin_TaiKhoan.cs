using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class ThongTin_TaiKhoan
    {
        public ThongTin_TaiKhoan()
        {
            HoaDonMaNguoiMuaNavigation = new HashSet<HoaDon>();
            HoaDonMaNguoiTaoNavigation = new HashSet<HoaDon>();
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public string MaTttk { get; set; }
        public string HovaTen { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<HoaDon> HoaDonMaNguoiMuaNavigation { get; set; }
        public virtual ICollection<HoaDon> HoaDonMaNguoiTaoNavigation { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
