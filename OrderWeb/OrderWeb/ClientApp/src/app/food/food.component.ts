import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $: any;
 
@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  //styleUrls: ['./food.component.css']
})
export class FoodComponent {
    
    size: Number = 5; //Mặc định
    keyWord: String = ""; //Mặc định

    isEdit: Boolean = false; //Kiểm tra thêm hay sửa

    //Khởi tạo biến nhận response User
    foods: any = {
        data: [],
        totalRecords: 0,
        page: 0,
        size: 5,
        totalPages: 0,
    };
    //
    food: any = {
      maThucAn: "",
      maLoai: "",
      tenThucAn: "",
      gia: 0,
      giamGia: 0,
      chiChu: ""
    }
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.searchFood(1);
    }
    //Tìm
    searchFood(cPage) {
        var value = {
            size: this.size,
            page: cPage,
            keyWord: ""
        }
        //Các value truyền vào phải giống tên với các tham số phía back-end
        //post
        this.http.post('https://localhost:44387/api/ThucAn/search-thuc', value).subscribe(
            result => {
                var res: any = result;
                // Sử dụng SingleRsp
                // Thu được dữ liệu
                if (res != null) {
                    this.foods = res;
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
    createFood() {
        //Chuyển dữ liệu chữ sang số sau khi nhập
        try
        {
            this.food.gia = parseInt(this.food.gia);
            this.food.giamGia = parseInt(this.food.giamGia);
        }
        catch
        {
            //Nếu parse lỗi chuyển hết về 0
            this.food.gia = 0
            this.food.giamGia = 0
        }
        //post
        this.http.post('https://localhost:44387/api/ThucAn/create-thucAn', this.food).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res.success) {
                    this.food = res;
                    alert("Đã tạo danh mục mới !!");
                    this.searchFood(1); //Quay về trang 1
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
    updateFood() {
        //post
        this.http.post('https://localhost:44387/api/ThucAn/update-thucAn', this.food).subscribe(
            result => {
                var res: any = result;
                //Thu được dữ liệu
                if (res != null) {
                    this.food = res.data;
                    alert("Đã sửa món ăn hiện tại !!");
                    this.searchFood(1); //Quay về trang 1
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
    deleteFood(foodId) {
        var check = confirm("Bạn có chắc chắn xóa danh mục này ?"); //Tạo thông báo xác nhận xóa
        if (check == true) {
            //delete
            this.http.post('https://localhost:44387/api/ThucAn/delete-thucAn?maThucAn=' + foodId, foodId).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.foods = res;
                        alert("Đã xóa món ăn hiện tại !!");
                        this.searchFood(1); //Quay về trang 1
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
            this.food = this.foods.data[index];
        }
        else {
            //thêm mới
            this.food = {
                maThucAn: "",
                maLoai: "",
                tenThucAn: "",
                gia: "",
                giamGia: "",
                chiChu: ""
            }
        }
    }
    //Các hàm liên quan đến phân trang
    goNext() {
        if (this.foods.page < this.foods.totalPages) {
            this.foods.page = this.foods.page + 1;
            this.searchFood(this.foods.page);
        }
        else {
            alert("Bạn đang ở trang cuối !!!")
        }
    }
    goPrevious() {
        if (this.foods.page > 1) {
            this.foods.page = this.foods.page - 1;
            this.searchFood(this.foods.page);
        }
        else {
            alert("Bạn đang ở trang đầu !!!")
        }
    }

}
