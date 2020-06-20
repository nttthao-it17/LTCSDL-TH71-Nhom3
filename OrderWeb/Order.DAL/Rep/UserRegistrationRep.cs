using LTCSDL.Common.DAL;
using LTCSDL.Common.Rsp;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Order.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Order.DAL.Rep
{

  public class UserRegistrationRep : GenericRep<OrderContext, User>
  {
    //Tạo tài khoản
    public SingleRsp AddAccount(User userregis)
    {
      var res = new SingleRsp();
      //Khởi tạo
      using (var context = new OrderContext())
      {
        using (var tran = context.Database.BeginTransaction())
        {
          try
          {
            context.User.Add(userregis); //Câu lệnh tạo của EF
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



      //User x = new User();
      //var cnn = (SqlConnection)Context.Database.GetDbConnection();
      //if (cnn.State == ConnectionState.Closed)
      //  cnn.Open();
      //try
      //{
      //  string sql = "INSERT INTO[User]([MaNguoiDung],[TenNguoiDung],[Email],[MatKhau],[MaLoai],[DiaChi],[SoDienThoai]) " +
      //    "VALUES( '" + user.MaNguoiDung + "','" + user.TenNguoiDung + "', '" + user.Email + "','" + user.MatKhau + "','" + user.MaLoai + "','" + user.DiaChi + "','" + user.SoDienThoai + ")";
      //  //sql = sql + "select * from [User] where MaNguoiDung = @@IDENTITY";
      //  DataSet ds = new DataSet();
      //  SqlDataAdapter da = new SqlDataAdapter();
      //  var cmd = cnn.CreateCommand();
      //  cmd.CommandText = sql;
      //  cmd.CommandType = CommandType.Text;
      //  da.SelectCommand = cmd;
      //  da.Fill(ds);
      //  if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
      //  {
      //    foreach(DataRow row in ds.Tables[0].Rows)
      //    {
      //      x = new User
      //      {
      //        MaNguoiDung = row["MaNguoiDung"].ToString(),
      //        TenNguoiDung = row["TenNguoiDung"].ToString(),
      //        Email = row["Email"].ToString(),
      //        MatKhau = row["MatKhau"].ToString(),
      //        MaLoai = row["MaLoai"].ToString(),
      //        DiaChi = row["DiaChi"].ToString(),
      //        SoDienThoai = row["SoDienThoai"].ToString(),
      //      };
      //    }
      //  }
      //}
      //catch(Exception e)
      //{
      //  x = null;
      //}
      /*  return x;*/
    }
  }
}
