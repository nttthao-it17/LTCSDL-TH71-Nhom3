using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class TaiKhoan
    {
        public string MaTk { get; set; }
        public string MaTttk { get; set; }
        public string TenTk { get; set; }
        public string MatKhau { get; set; }
        public int LoaiTk { get; set; }
        public string GhiChu { get; set; }

        public virtual ThongTin_TaiKhoan MaTttkNavigation { get; set; }
    }
}
