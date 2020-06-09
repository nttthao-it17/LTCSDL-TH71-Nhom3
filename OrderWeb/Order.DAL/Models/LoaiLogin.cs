using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class LoaiLogin
    {
        public string MaLoaiLogin { get; set; }
        public string MaNguoiDung { get; set; }

        public virtual Login MaNguoiDungNavigation { get; set; }
    }
}
