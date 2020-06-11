using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Order.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Order.DAL.Rep
{
    public class OrderRep : GenericRep<OrderContext, Models.Order>
    {
        //create
        public SingleRsp Create(Models.Order order)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Order.Add(order); //Câu lệnh tạo của EF
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
        public SingleRsp Update(Models.Order order)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Order.Update(order); //Câu lệnh sửa của EF
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
                    var u = context.Order.FirstOrDefault(value => value.MaOrder == maOrder);
                    try
                    {
                        context.Order.Remove(u); //Câu lệnh xóa của EF
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
