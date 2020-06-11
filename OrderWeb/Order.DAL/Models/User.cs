using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            UserDetail = new HashSet<UserDetail>();
        }

        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string MaLoai { get; set; }
        public string GhiChu { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<UserDetail> UserDetail { get; set; }
    }
}
