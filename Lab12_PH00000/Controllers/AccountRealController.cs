using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Lab12_PH00000.Controllers
{
    public class AccountRealController : Controller
    {
        // Constructor - dừng để khởi tạo thuộc tính cho đối tượng
        // Không tham số: Khởi tạo thuộc tính với giá trị mặc định
        // Có tham số: Khởi tạo thuộc tính với giá trị được truyền vào
        public AccountRealController()
        {
        }
        // Các phương thức
        public IActionResult Login(string username, string password)
        {
            // Bước 1: Lấy dữ liệu ra từ db
            // Tư duy a: Lấy ra tất cả các account sau đó kiểm tra xem có username,
            // hay password nào như thế trong db hay không? (Toàn năng hơn)
            // Tư duy b: thực hiện duy nhất 1 truy vấn select from where ... để xem trong
            // db có account đấy hay không? (Nhanh hơn vì nó chỉ check thôi)
            // ExecuteNonQuery sẽ trả về số row mà truy vấn tương tác lên nó ((row affected) (Insert, Delete, Update)
            // ExecuteScalar sẽ trả về row đầu tiên mà truy vấn lấy ra được
            // ExecuteReader sẽ trả về các row mà truy vấn lấy ra được
            if (username == null || password == null)
            {
                return View();
            }
            else
            {
                string query = $"select * from account " +
                    $"where username ='{username}' and password = '{password}'";
                string connectionString = @"Data Source=SHANGHAIK;Initial Catalog=SD19314;Integrated Security=True;TrustServerCertificate=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString); // Tạo 1 sqlConnectio dựa theo connectionstring vừa tạo
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection); // Tạo 1 command để thực hiện chạy câu lệnh
                                                                              // Thực hiện truy vấn
                try
                {
                    // Mở connect 
                    sqlConnection.Open();
                    var row = sqlCommand.ExecuteScalar();
     
                    if (row != null)
                    {
                        ViewData["account"] = username; 
                        TempData["account"] = username;
                        return RedirectToAction("Index", "Hame");
                    }
                    else ViewData["account"] = "Không có tài khoản nào như vậy cả";
                }
                catch (Exception e)
                {
                    return Content("Lỗi rồi cụ ơi" + e.Message);
                }
                finally
                { // Câu lệnh trong finnaly luôn luôn được chạy mặc cho truy vấn có thành công hay ko
                    sqlConnection.Close();
                }
                return View();
            }

        }
    }
}
