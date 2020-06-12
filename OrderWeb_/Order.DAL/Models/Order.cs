using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class Order
    {
        public string MaOrder { get; set; }
        public string MaThucAn { get; set; }
        public string TenThucAn { get; set; }
        public int? Gia { get; set; }
        public int? GiamGia { get; set; }
        public DateTime? NgayDatMon { get; set; }
        public string MaNguoiDung { get; set; }

        public virtual User MaNguoiDungNavigation { get; set; }
        public virtual ThucAn MaThucAnNavigation { get; set; }
    }
}
