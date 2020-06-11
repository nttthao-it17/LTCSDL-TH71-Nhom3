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
        //Delete
        public SingleRsp DeleteOrder(String maOrder)
        {
            var res = new SingleRsp();
            res = _rep.Delete(maOrder);
            return res;
        }

    }
}
