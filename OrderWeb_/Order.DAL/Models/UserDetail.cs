using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class UserDetail
    {
        public string MaLoaiLogin { get; set; }
        public string MaNguoiDung { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string GhiChu { get; set; }

        public virtual User MaNguoiDungNavigation { get; set; }
    }
}
