using System;
using System.Collections.Generic;

namespace Order.DAL.Models
{
    public partial class LoaiThucAn
    {
        public LoaiThucAn()
        {
            ThucAn = new HashSet<ThucAn>();
        }

        public string MaLoai { get; set; }
        public string TenLoaiThucAn { get; set; }

        public virtual ICollection<ThucAn> ThucAn { get; set; }
    }
}
