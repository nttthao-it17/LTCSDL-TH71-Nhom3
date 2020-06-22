using LTCSDL.Common.BLL;
using Order.DAL.Models;
using Order.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.BLL.Svc
{
  public class GetOrdersListSvc : GenericSvc<GetOrdersListRep, Orders>
  {
    public object GetDanhSachDonHang(DateTime datef, DateTime datet, int size, int page)
    {
      return _rep.GetDanhSachDonHang(datef, datet, size, page);
    }
  }
}
