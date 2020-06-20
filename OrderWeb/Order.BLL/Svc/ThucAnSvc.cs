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
    public class ThucAnSvc : GenericSvc<ThucAnRep, ThucAn>
    {
        //Sử dụng hàm tạo
        public SingleRsp CreateThucAn(ThucAnReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo user
            ThucAn thucAn = new ThucAn();
            //Gán giá trị
            thucAn.MaThucAn = req.MaThucAn;
            thucAn.MaLoai = req.MaLoai;
            thucAn.TenThucAn = req.TenThucAn;
            thucAn.Gia = req.Gia;
            thucAn.GiamGia = req.GiamGia;
            thucAn.GhiChu = req.GhiChu;
            //Tạo sau khi gán giá trị
            res = base.Create(thucAn);
            res.Data = thucAn;
            return res;
        }
        public SingleRsp UpdateThucAn(ThucAnReq req)
        {
            var res = new SingleRsp();
            //Khởi tạo user
            ThucAn thucAn = new ThucAn();
            //Gán giá trị
            thucAn.MaThucAn = req.MaThucAn;
            thucAn.MaLoai = req.MaLoai;
            thucAn.TenThucAn = req.TenThucAn;
            thucAn.Gia = req.Gia;
            thucAn.GiamGia = req.GiamGia;
            thucAn.GhiChu = req.GhiChu;
            //Tạo sau khi gán giá trị
            res = base.Update(thucAn);
            res.Data = thucAn;
            return res; ;
        }
        //search
        public object SearchThucAn(int size, int page, String keyWord)
        {
            //Khởi tạo các đối tượng
            //Lấy tất cả giá trị
            var allValues = _rep.All; //Đối tượng search chỉ dùng biến ALL để get all data. Không sử dụng hàm
            //Kiểm tra keyword
            if (!string.IsNullOrEmpty(keyWord))
            {
                //Có dữ liệu
                allValues = _rep.All.Where(value => value.MaThucAn.Contains(keyWord) //Kiểm tra theo mã
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
        //delete
        public SingleRsp DeleteThucAn(String maThucAn)
        {
            var res = new SingleRsp();
            res = _rep.Delete(maThucAn);
            return res;
        }
    }
}
