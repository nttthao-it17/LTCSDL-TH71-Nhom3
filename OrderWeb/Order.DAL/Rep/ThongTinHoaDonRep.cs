using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Order.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Order.DAL.Rep
{
  public class ThongTinHoaDonRep : GenericRep<OrderContext, ThongTinHoaDon>
  {
    //create
    public SingleRsp Create(ThongTinHoaDon ttHoaDon)
    {
      var res = new SingleRsp();
      //Khởi tạo
      using (var context = new OrderContext())
      {
        using (var tran = context.Database.BeginTransaction())
        {
          try
          {
            context.ThongTinHoaDon.Add(ttHoaDon); //Câu lệnh tạo của EF
            context.SaveChanges();
            tran.Commit();
          }
          catch (Exception ex)
          {
            tran.Rollback();
            res.SetError(ex.StackTrace); //Xuất lỗi
          }
        }
      }
      return res;
    }
    //Update
    public SingleRsp Update(ThongTinHoaDon ttHoaDon)
    {
      var res = new SingleRsp();
      //Khởi tạo
      using (var context = new OrderContext())
      {
        using (var tran = context.Database.BeginTransaction())
        {
          try
          {
            context.ThongTinHoaDon.Update(ttHoaDon); //Câu lệnh sửa của EF
            context.SaveChanges();
            tran.Commit();
          }
          catch (Exception ex)
          {
            tran.Rollback();
            res.SetError(ex.StackTrace); //Xuất lỗi
          }
        }
      }
      return res;
    }
    //Delete
    public SingleRsp Delete(String maOrder)
    {
      var res = new SingleRsp();
      //Khởi tạo
      using (var context = new OrderContext())
      {
        using (var tran = context.Database.BeginTransaction())
        {
          var u = context.ThongTinHoaDon.FirstOrDefault(value => value.MaOrder == maOrder);
          try
          {
            context.ThongTinHoaDon.Remove(u); //Câu lệnh xóa của EF
            context.SaveChanges();
            tran.Commit();
          }
          catch (Exception ex)
          {
            tran.Rollback();
            res.SetError(ex.StackTrace); //Xuất lỗi
          }
        }
      }
      return res;
    }
  }
  
}
