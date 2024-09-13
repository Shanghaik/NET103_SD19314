using Microsoft.AspNetCore.Mvc;

namespace Lab12_PH00000.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string username, string password)
        {
            // Khi mới bật view lên thì username và password => Không có gì
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))// check rỗng
            {
                return View();
            }
            else // Nếu username = admin và password không rỗng thì chuyển hướng về trang chủ /Home/Index
            {
                if (username.ToLower() == "admin" && password.Trim().Length > 0)
                {
                    TempData["message"] = "Bạn đã đăng nhập với username: " + username; //Key = account, value = giá trị của username truyền vào
                    return RedirectToAction("Index", "Hame");
                }
                else
                {
                    TempData["message"] = "Bạn đã đăng nhập với username: " + username;
                    return RedirectToAction("Privacy", "Hame");
                } // Thầy đổi tên nên là Hame, của các bạn là Home
            }// Truyền dữ liệu với TempData/ViewBag/ViewData
             // TempData sẽ cho phép lưu tạm dữ liệu xuyên suốt giữa 2 request (yêu cầu)
             // Tempdata hoạt động theo cơ chế Key_value
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
