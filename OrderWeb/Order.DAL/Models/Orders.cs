using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class Orders
    {
        public Orders()
        {
            ThongTinHoaDon = new HashSet<ThongTinHoaDon>();
        }

        public string MaOrder { get; set; }
        public DateTime? NgayDatMon { get; set; }
        public string MaNguoiDung { get; set; }
        public string GhiChu { get; set; }

        public virtual User MaNguoiDungNavigation { get; set; }
        public virtual ICollection<ThongTinHoaDon> ThongTinHoaDon { get; set; }
    }
}
