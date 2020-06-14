import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;


@Component({
  selector: 'app-hoa-don',
  templateUrl: './hoa-don.component.html',
 // styleUrls: ['./hoa-don.component.css']
})
export class HoaDonComponent  {

  size: Number = 5; //Mặc định
  keyWord: String = ""; //Mặc định

  isEdit: Boolean = false; //Kiểm tra thêm hay sửa

  nowDate: Date = new Date(); //Ngày hôm nay
  //Khởi tạo biến nhận response User
  hoadons: any = {
      data: [],
      totalRecords: 0,
      page: 0,
      size: 5,
      totalPages: 0,
  };
  //
  hoadon: any = {
      maOrder: "",
      maThucAn: "",
      tenThucAn: "",
      gia: 0,
      giamGia: 0,
      ngayDatMon: this.nowDate.toJSON(),
      maNguoiDung: ""
  }
  public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.searchHoaDon(1);
  }
  //Tìm
  searchHoaDon(cPage) {
      var value = {
          size: this.size,
          page: cPage,
          keyWord: ""
      }
      //Các value truyền vào phải giống tên với các tham số phía back-end
      //post
      this.http.post('https://localhost:44387/api/Order/search-order', value).subscribe(
          result => {
              var res: any = result;
              // Sử dụng SingleRsp
              // Thu được dữ liệu
              if (res != null) {
                  this.hoadons = res;
              }
              //Không thu được dữ liệu
              else {
                  alert(res.message);
              }
          },
          error => {
              alert("Server error!!")
          });
  }
  //Tạo
  createHoaDon() {
       //Chuyển dữ liệu chữ sang số sau khi nhập
       try
       {
           this.hoadon.gia = parseInt(this.hoadon.gia);
           this.hoadon.giamGia = parseInt(this.hoadon.giamGia);
       }
       catch
       {
           //Nếu parse lỗi chuyển hết về 0
           this.hoadon.gia = 0
           this.hoadon.giamGia = 0
       }
      //post
      this.http.post('https://localhost:44387/api/Order/create-Order', this.hoadon).subscribe(
          result => {
              var res: any = result;
              //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
              //Thu được dữ liệu
              if (res.success) {
                  this.hoadon = res;
                  alert("Đã tạo danh mục mới !!");
                  this.searchHoaDon(1); //Quay về trang 1
              }
              //Không thu được dữ liệu
              else {
                  alert(res.message);
              }
          },
          error => {
              alert("Server error!!")
          });
  }
  //Sửa
  updateHoaDon() {
      //post
      this.http.post('https://localhost:44387/api/Order/update-order', this.hoadon).subscribe(
          result => {
              var res: any = result;
              //Thu được dữ liệu
              if (res != null) {
                  this.hoadon = res.data;
                  alert("Đã sửa hóa đơn hiện tại !!");
                  this.searchHoaDon(1); //Quay về trang 1
              }
              //Không thu được dữ liệu
              else {
                  alert(res.message);
              }
          },
          error => {
              alert("Server error!!")
          });
  }
  //Xóa
  deleteHoaDon(maOrder) {
      var check = confirm("Bạn có chắc chắn xóa danh mục này ?"); //Tạo thông báo xác nhận xóa
      if (check == true) {
          //delete
          this.http.post('https://localhost:44387/api/Order/delete-order?maOrder=' + maOrder, maOrder).subscribe(
              result => {
                  var res: any = result;
                  //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                  //Thu được dữ liệu
                  if (res != null) {
                      this.hoadons = res;
                      alert("Đã xóa hóa đơn hiện tại !!");
                      this.searchHoaDon(1); //Quay về trang 1
                  }
                  //Không thu được dữ liệu
                  else {
                      alert(res.message);
                  }
              },
              error => {
                  alert("Server error!!")
              });
      }
  }
  //Các hàm liên quan tới modal
  openCreateUpdateModal(isEdit, index) //Kiểm tra là thêm hay sửa
  {
      this.isEdit = isEdit;
      $('#openCreateUpdateModal').modal('show');
      this.checkEdit(isEdit, index);
  }
  //Các hàm khác
  checkEdit(isEdit, index) {
      if (isEdit) {
          this.hoadon = this.hoadons.data[index];
      }
      else {
          //thêm mới
          this.hoadon = {
            maOrder: "o08",
            maThucAn: "ta01",
            tenThucAn: "cd",
            gia: 0,
            giamGia: 0,
            ngayDatMon: this.nowDate.toJSON(),
            maNguoiDung: "nd02"
          }
      }
  }
  //Các hàm liên quan đến phân trang
  goNext() {
      if (this.hoadons.page < this.hoadons.totalPages) {
          this.hoadons.page = this.hoadons.page + 1;
          this.searchHoaDon(this.hoadons.page);
      }
      else {
          alert("Bạn đang ở trang cuối !!!")
      }
  }
  goPrevious() {
      if (this.hoadons.page > 1) {
          this.hoadons.page = this.hoadons.page - 1;
          this.searchHoaDon(this.hoadons.page);
      }
      else {
          alert("Bạn đang ở trang đầu !!!")
      }
  }
}
