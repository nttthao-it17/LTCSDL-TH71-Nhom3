using LTCSDL.Common.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Order.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Order.DAL.Rep
{
  public class GetOrdersListRep : GenericRep<OrderContext, Orders>
  {
    public object GetDanhSachDonHang(DateTime datef, DateTime datet, int size, int page)
    {
      List<object> res = new List<object>();
      var cnn = (SqlConnection)Context.Database.GetDbConnection();
      if (cnn.State == ConnectionState.Closed)
        cnn.Open();
      try
      {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        var cmd = cnn.CreateCommand();
        cmd.CommandText = "Sp_DanhSachDonHang";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@dateFrom", datef);
        cmd.Parameters.AddWithValue("@dateTo", datet);
        cmd.Parameters.AddWithValue("@size", size);
        cmd.Parameters.AddWithValue("@page", page);
        da.SelectCommand = cmd;
        da.Fill(ds);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
          foreach (DataRow row in ds.Tables[0].Rows)
          {
            var x = new
            {
              stt = row["stt"],
              MaOrder = row["MaOrder"],
              NgayDatMon = row["NgayDatMon"],
              MaNguoiDung = row["MaNguoiDung"],
              GhiChu = row["GhiChu"]
            };
            res.Add(x);
          }
        }
      }
      catch (Exception e)
      {
        res = null;
      }
      return res;
    }
  }

}
