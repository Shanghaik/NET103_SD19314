using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_EFCore.Models;

namespace MVC_EFCore.Controllers
{
    public class SenController : Controller
    {
        // GET: SenController
        PETContext _context = new PETContext(); // Khai báo và khởi tạo context (tạo luôn ở đây nếu sợ quên)
        public SenController()
        {
            _context = new PETContext();
        }
        public ActionResult Index()
        {
            var listItem = _context.Sens.ToList();
            return View(listItem);
        }

        // GET: SenController/Details/5
        public ActionResult Details(int id)
        {
            var item = _context.Sens.Find(id); // Phương thức Find(key) chỉ dùng với khóa chính
            return View(item);
        }

        // GET: SenController/Create
        public ActionResult Create() // Action này để trả về cái View (chưa có data) - hiển thị form điền
        {
            // Tạo data Mẫu để truyền sang View
            Sen sen = new Sen() { Ten = "Dữ liệu mẫu", Sdt = "12345", DiaChi= "Gầm cầu" };
            return View(sen);
        }

        // POST: SenController/Create
        [HttpPost]
        public ActionResult Create(Sen sen)
        {
            try
            {
                _context.Sens.Add(sen); // Thêm đối tượng vào Db thông qua DbSet
                _context.SaveChanges(); // Lưu lại thay đổi
                return RedirectToAction("Index");   
            }
            catch(Exception e)
            {
                return Content(e.Message);   
            }
        }

        // GET: SenController/Edit/5
        public ActionResult Edit(int id) // Action để mở View
        {
            var editItem = _context.Sens.Find(id); // Lấy để truyền data sang View
            return View(editItem);
        }

        // POST: SenController/Edit/5
        [HttpPost]
        public ActionResult Edit(Sen sen)
        {
            //var editItem = _context.Sens.Find(sen.Id); // Lấy để sửa
            //editItem.Ten = sen.Ten;
            //editItem.Sdt = sen.Sdt;
            //editItem.DiaChi = sen.DiaChi;
            try 
            {
                _context.Sens.Update(sen);
                _context.SaveChanges();
                return RedirectToAction("Index");   
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        // GET: SenController/Delete/5
        public ActionResult Delete(int id)
        {
            // Muốn xóa phải tìm ra đối tượng cần xóa đã
            var deleteItem = _context.Sens.Find(id);    
            _context.Sens.Remove(deleteItem);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      
    }
}
