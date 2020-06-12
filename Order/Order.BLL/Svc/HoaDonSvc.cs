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
    public class HoaDonSvc : GenericSvc<HoaDonRep, DAL.Models.HoaDon>
    {
        //Sử dụng hàm tạo
        public SingleRsp CreateOrder(HoaDonReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo order
            DAL.Models.HoaDon order = new DAL.Models.HoaDon();
            //Gán giá trị
            order.MaHoaDon = req.MaHoaDon;
            order.MaNguoiMua = req.MaNguoiMua;
            order.MaNguoiTao = req.MaNguoiTao;
            order.ThoiGianTao = req.ThoiGianTao;
            order.ThoiGianIn = req.ThoiGianIn;
     
            //Tạo sau khi gán giá trị
            res = base.Create(order);
            res.Data = order;
            return res;
        }
        //Update
        public SingleRsp UpdateOrder(HoaDonReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo order
            DAL.Models.HoaDon order = new DAL.Models.HoaDon();
      //Gán giá trị
            order.MaHoaDon = req.MaHoaDon;
            order.MaNguoiMua = req.MaNguoiMua;
            order.MaNguoiTao = req.MaNguoiTao;
            order.ThoiGianTao = req.ThoiGianTao;
            order.ThoiGianIn = req.ThoiGianIn;
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
