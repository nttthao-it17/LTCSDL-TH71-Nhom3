import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var $: any;

@Component({
    selector: 'app-user-order',
    templateUrl: './user.component.html',
    //styleUrls: ['./user.component.scss']
})
export class UserComponent {

    size: Number = 5; //Mặc định
    keyWord: String = ""; //Mặc định

    isEdit: Boolean = false; //Kiểm tra thêm hay sửa

    //Khởi tạo biến nhận response User
    users: any = {
        data: [],
        totalRecords: 0,
        page: 0,
        size: 5,
        totalPages: 0,
    };
    //
    user: any = {
        maNguoiDung: "",
        tenNguoiDung: "",
        email: "",
        matKhau: "",
        maLoai: "",
        ghiChu: ""
    }
    public constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.searchUser(1);
    }
    //Tìm
    searchUser(cPage) {
        var value = {
            size: this.size,
            page: cPage,
            keyWord: ""
        }
        //Các value truyền vào phải giống tên với các tham số phía back-end
        //post
        this.http.post('https://localhost:44387/api/User/search-user', value).subscribe(
            result => {
                var res: any = result;
                // Sử dụng SingleRsp
                // Thu được dữ liệu
                if (res != null) {
                    this.users = res;
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
    createUser() {
        //post
        this.http.post('https://localhost:44387/api/User/create-user', this.user).subscribe(
            result => {
                var res: any = result;
                //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                //Thu được dữ liệu
                if (res != null) {
                    this.user = res;
                    alert("Đã tạo danh mục mới !!");
                    this.searchUser(1); //Quay về trang 1
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
    updateUser() {
        //post
        this.http.post('https://localhost:44387/api/User/update-user', this.user).subscribe(
            result => {
                var res: any = result;
                //Thu được dữ liệu
                if (res != null) {
                    this.user = res.data;
                    alert("Đã sửa người dùng hiện tại !!");
                    this.searchUser(1); //Quay về trang 1
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
    deleteUser(userId) {
        var check = confirm("Bạn có chắc chắn xóa danh mục này ?"); //Tạo thông báo xác nhận xóa
        if (check == true) {
            //delete
            this.http.post('https://localhost:44387/api/User/delete-user?userId=' + userId, userId).subscribe(
                result => {
                    var res: any = result;
                    //Phần này dùng lấy dữ liệu không xài SingleRsp dưới Back-End
                    //Thu được dữ liệu
                    if (res != null) {
                        this.users = res;
                        alert("Đã xóa người dùng hiện tại !!");
                        this.searchUser(1); //Quay về trang 1
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
            this.user = this.users.data[index];
        }
        else {
            //thêm mới
            this.user = {
                maNguoiDung: "",
                tenNguoiDung: "",
                email: "",
                matKhau: "",
                maLoai: "",
                ghiChu: ""
            }
        }
    }
    //Các hàm liên quan đến phân trang
    goNext() {
        if (this.users.page < this.users.totalPages) {
            this.users.page = this.users.page + 1;
            this.searchUser(this.users.page);
        }
        else {
            alert("Bạn đang ở trang cuối !!!")
        }
    }
    goPrevious() {
        if (this.users.page > 1) {
            this.users.page = this.users.page - 1;
            this.searchUser(this.users.page);
        }
        else {
            alert("Bạn đang ở trang đầu !!!")
        }
    }
}
