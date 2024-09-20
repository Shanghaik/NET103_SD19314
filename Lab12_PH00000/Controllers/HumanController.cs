using Lab12_PH00000.Models.TestModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab12_PH00000.Controllers
{
    public class HumanController : Controller
    {
        public IActionResult Index()
        {
            Human hm = new Human()
            {
                CCCD = "0010100010011",
                SDT = "09999999999",
                Ten = "Đại Văn Gia",
                Luong = 10000000000,
                Tuoi = 19
            };
            Animal am = new Animal()
            {
                Ten = "Chó",
                SoChan = 4
            };
            // ViewData hoạt động theo cơ chế Key-Value như TempData
            // nhưng nó chỉ tồn tại trong 1 request khác với TempData sẽ tồn tại giữa 2 request
            // ViewData được dùng để truyền dữ liệu từ controller sang View ứng với
            // tên của Action tương ứng, đồng nghĩa với việc nó chỉ dùng được trong 1 view
            ViewData["animal"] = am;
            // Truyền dữ liệu sang View bằng cách đưa vào phương thức View
            return View(hm);
        }
        public IActionResult GetListHuman()
        {
            List<Human> list = new List<Human>()
            {
                new Human(){CCCD = "0010100010012",SDT = "09999999999",Ten = "Đại Văn Gia",
                Luong = 10000000000,Tuoi = 19 },
                new Human(){CCCD = "0010100010014",SDT = "09999111111",Ten = "Tiểu Văn Gia",
                Luong = 10000000000,Tuoi = 34 },
                new Human(){CCCD = "0010100010016",SDT = "09999666666",Ten = "Trung Văn Gia",
                Luong = 10000000000,Tuoi = 19 },
                new Human(){CCCD = "0010100010018",SDT = "09999444444",Ten = "Trần Xuân Huấn",
                Luong = 1000000,Tuoi = 49 }
            };
            // Truyền cả 1 List đối tượng sang View
            return View(list);
        }
            
    }
}

