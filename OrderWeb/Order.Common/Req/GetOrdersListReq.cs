using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Common.Req
{
  public class GetOrdersListReq
  {
    public DateTime dateFrom { get; set; }
    public DateTime dateTo { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
  }
}
