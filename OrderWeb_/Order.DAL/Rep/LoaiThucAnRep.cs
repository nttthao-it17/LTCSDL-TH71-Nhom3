using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Order.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.DAL.Rep
{
    public class LoaiThucAnRep : GenericRep<OrderContext, LoaiThucAn>
    {
        //create
        public SingleRsp Create(LoaiThucAn loaiThucAn)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiThucAn.Add(loaiThucAn); //Câu lệnh tạo của EF
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
        public SingleRsp Update(LoaiThucAn loaiThucAn)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiThucAn.Update(loaiThucAn); //Câu lệnh sửa của EF
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
        public SingleRsp Delete(String maLoaiThucAn)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var u = context.LoaiThucAn.FirstOrDefault(value => value.MaLoai == maLoaiThucAn);
                    try
                    {
                        context.LoaiThucAn.Remove(u); //Câu lệnh xóa của EF
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

