using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Order.Common.Req;
using Order.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.DAL.Rep
{
    public class UserRep : GenericRep<OrderContext, User>
    {

        //create
        public SingleRsp Create(User user)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.User.Add(user); //Câu lệnh tạo của EF
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
        public SingleRsp Update(User user)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.User.Update(user); //Câu lệnh sửa của EF
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
        public SingleRsp Delete(String userId)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    var u = context.User.FirstOrDefault(value => value.MaNguoiDung == userId);
                    try
                    {
                        context.User.Remove(u); //Câu lệnh xóa của EF
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

        public SingleRsp Login(LoginReq req)
        {
           SingleRsp res = new SingleRsp();
      User user = Context.User.SingleOrDefault(user => user.Email.Equals(req.email));
      if(user != null)
      {
        if (user.MatKhau.Equals(req.password))
        {
          res.Data = Context.User.Where(u => u.Email.Equals(req.email)).FirstOrDefault();
        

        } else
        {
          res.SetError("Mat khau khong hop le");
        }
      }
      else
      {
        res.SetError("nguoi dung khong ton tai");
      }
      return res;
        }
    }
    //Scaffold-DbContext "Data Source=DESKTOP-8CB76R1\HUEJH;Initial Catalog=Order;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
}
