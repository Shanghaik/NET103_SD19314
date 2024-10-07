using Microsoft.AspNetCore.Mvc;

namespace MVC_EFCore.Controllers
{
    public class SessionController : Controller
    {
        // Session là một cơ chế lưu trữ dữ liệu tạm thời trên webserver của UD
        // Session có một bộ đếm thời gian hoạt động theo cơ chế bộ đếm sẽ đếm ngược
        // theo một khoảng thời gian nhất định tính từ thời điểm có một Request được
        // tạo ra. Nếu trong khoảng gian timeout mà lại tiếp tục có 1 request thì 
        // bộ đếm sẽ được khởi tạo lại. Nếu không dữ liệu trong Session sẽ bị xóa.
        // Ví dụ: Thầy giáo yêu cầu cả lớp im lặng trong 10 phút thì cả lớp sẽ được
        // + 1 điểm. Tuy nhiên khi đến phút thứ 7 thì 1 bạn không may thở hơi to, bộ
        // đếm thời gian reset lại.
        // IActionResult là một kiểu trả về của Action trong Controller có thể trả về
        // nhiều loại result là: JsonResult, ContentResult,...
        // Khi sử dụng Bất đồng bộ, chúng ta thường thêm Task<IActionResult> và từ
        // khóa async. Bất đồng bộ cho phép nâng cao hiệu xuất ứng dụng vì nó cho phép
        // các luồng nhỏ được chạy liên tục mà không làm chặn luồng chính.
        // VD: Hôm nay nhà bạn X mời cơm các bạn ABC. Khi đến thì Bạn X sẽ đi nấu cơm, Bạn A sẽ
        // đi thịt gà, bạn B đi nhặt rau, bạn C đi quét nhà. tuy nhiên khi bạn X nấu cơm sẽ không
        // chờ cơm chín mà có thể đi đun nước sôi trong khi bạn A đang ra chuồng bắt gà. ĐIều
        // này thường thực hiện theo cơ chế thread pool từ là mỗi thread sẽ không nghỉ trừ khi
        // số luồng cần thực thi ít hơn số tác vụ đang cần.
        // Đồng bộ: làm từ A đến Z, khi nào xong làm việc khác.
        // Bất đồng bộ: Không đợi từ A-Z mà bắt tay làm thêm việc khác khi đang đến Z để cải thiện
        // hiệu xuất.
        public IActionResult UseSession(string message)
        {
            message = "Hello Các bạng";
            // Thêm dữ liệu vào Session
            HttpContext.Session.SetString("message", message);
            // Sau khi thêm dữ luệ vào Session thì nó thể gọi nó ra ở bất kì đâu
            return RedirectToAction("Index", "Home");
        }
    }
}
