using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class Login
    {
        public Login()
        {
            LoaiLogin = new HashSet<LoaiLogin>();
        }

        public string MaNguoiDung { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string MaLoai { get; set; }

        public virtual ICollection<LoaiLogin> LoaiLogin { get; set; }
    }
}
