using LTCSDL.Common.BLL;
using LTCSDL.Common.Rsp;
using Order.Common.Req;
using Order.DAL.Models;
using Order.DAL.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.BLL.Svc
{
  public class ThongTinHoaDonSvc : GenericSvc<ThongTinHoaDonRep, ThongTinHoaDon>
  {
    //Sử dụng hàm tạo
    public SingleRsp CreateThongTinHoaDon(ThongTinHoaDonReq req)
    {
      var res = new SingleRsp();
      //Khởi tạo order
      ThongTinHoaDon ttHoaDon = new ThongTinHoaDon();
      //Gán giá trị
      ttHoaDon.MaOrder = req.MaOrder;
      ttHoaDon.MaThucAn = req.MaThucAn;
      ttHoaDon.Gia = req.Gia;
      ttHoaDon.GiamGia = req.GiamGia;
      ttHoaDon.GhiChu= req.GhiChu;
      //Tạo sau khi gán giá trị
      res = base.Create(ttHoaDon);
      res.Data = ttHoaDon;
      return res;
    }
    //Update
    public SingleRsp UpdateThongtinHoaDon(ThongTinHoaDonReq req)
    {
      var res = new SingleRsp();
      //Khởi tạo order
      ThongTinHoaDon ttHoaDon = new ThongTinHoaDon();
      //Gán giá trị
      ttHoaDon.MaOrder = req.MaOrder;
      ttHoaDon.MaThucAn = req.MaThucAn;
      ttHoaDon.Gia = req.Gia;
      ttHoaDon.GiamGia = req.GiamGia;
      ttHoaDon.GhiChu = req.GhiChu;
      //Tạo sau khi gán giá trị
      res = base.Update(ttHoaDon);
      res.Data = ttHoaDon;
      return res;
    }
    //search
    public object SearchThongTinHoaDon(int size, int page, String keyWord)
    {
      //Khởi tạo các đối tượng
      //Lấy tất cả giá trị
      var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
                                //Kiểm tra keyword
      if (!string.IsNullOrEmpty(keyWord))
      {
        //Có dữ liệu
        allValues = _rep.All.Where(value => value.MaOrder.Contains(keyWord) //Kiểm tra theo mã
        || value.MaThucAn.Contains(keyWord)); //Kiểm tra theo tên
      }
      //Độ dời
      int offset = (page - 1) * size;
      //Tổng số dữ liệu
      int total = allValues.Count();
      //Tổng số trang
      //Ví dụ: 12 DL / Size 5 thì bằng 2 sẽ dư 2. Do đó phải có 3 trang để chứa đủ 12 DL
      int totalPage = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
      //Dữ liệu theo trang
      var data = allValues.Skip(offset).Take(size).ToList(); //Trả về danh sách
      var result = new
      {
        Data = data,
        totalRecords = total,
        Page = page,
        Size = size,
        TotalPages = totalPage
      };
      return result;
    }
    //Delete
    public SingleRsp DeleteThongTinHoaDon(String maOrder)
    {
      var res = new SingleRsp();
      res = _rep.Delete(maOrder);
      return res;
    }


  }
}
