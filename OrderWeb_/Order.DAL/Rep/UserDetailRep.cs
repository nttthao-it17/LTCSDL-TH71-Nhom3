using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Order.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Order.DAL.Rep
{
    public class UserDetailRep : GenericRep<OrderContext, UserDetail>
    {
        //create
        public SingleRsp Create(UserDetail userDetail)
        {
            var res = new SingleRsp();
            //Khởi tạo
            using (var context = new OrderContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.UserDetail.Add(userDetail); //Câu lệnh tạo của EF
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
