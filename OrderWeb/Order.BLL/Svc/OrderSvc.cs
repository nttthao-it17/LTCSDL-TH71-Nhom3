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
    public class OrderSvc : GenericSvc<OrderRep, DAL.Models.Order>
    {
        //Sử dụng hàm tạo
        public SingleRsp CreateOrder(OrderReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo order
            DAL.Models.Order order = new DAL.Models.Order();
            //Gán giá trị
            order.MaOrder = req.MaOrder;
            order.MaThucAn = req.MaThucAn;
            order.TenThucAn = req.TenThucAn;
            order.Gia = req.Gia;
            order.GiamGia = req.GiamGia;
            order.NgayDatMon = req.NgayDatMon;
            order.MaNguoiDung = req.MaNguoiDung;
            //Tạo sau khi gán giá trị
            res = base.Create(order);
            res.Data = order;
            return res;
        }
        //Update
        public SingleRsp UpdateOrder(OrderReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo order
            DAL.Models.Order order = new DAL.Models.Order();
            //Gán giá trị
            order.MaOrder = req.MaOrder;
            order.MaThucAn = req.MaThucAn;
            order.TenThucAn = req.TenThucAn;
            order.Gia = req.Gia;
            order.GiamGia = req.GiamGia;
            order.NgayDatMon = req.NgayDatMon;
            order.MaNguoiDung = req.MaNguoiDung;
            //Tạo sau khi gán giá trị
            res = base.Update(order);
            res.Data = order;
            return res;
        }
        //search
        public object SearchOrder(int size, int page, String keyWord)
        {
          //Khởi tạo các đối tượng
          //Lấy tất cả giá trị
          var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
                                    //Kiểm tra keyword
          if (!string.IsNullOrEmpty(keyWord))
          {
            //Có dữ liệu
            allValues = _rep.All.Where(value => value.MaOrder.Contains(keyWord) //Kiểm tra theo mã
            || value.TenThucAn.Contains(keyWord)); //Kiểm tra theo tên
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
        public SingleRsp DeleteOrder(String maOrder)
            {
                var res = new SingleRsp();
                res = _rep.Delete(maOrder);
                return res;
            }

        }
}
