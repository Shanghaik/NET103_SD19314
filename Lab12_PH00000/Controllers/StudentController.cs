using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Lab12_PH00000.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Login()
        {
            return View(); // Return View là trả về View tương ứng với tên của Action
        }
        public IActionResult Register()
        {
            return View(); // Return View là trả về View tương ứng với tên của Action
        }
        public IActionResult GoHome()
        {
            //return RedirectToAction("Index", "Hame"); // Phương thức này điều hướng tới Action mà bạn cần
            return Redirect("/Hame/Index"); // Phương thức trỏ trực tiếp tới View mà bạn cần nếu không có logic nào cả
        }

    }
}
