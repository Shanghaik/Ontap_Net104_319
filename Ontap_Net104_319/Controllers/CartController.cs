using Microsoft.AspNetCore.Mvc;
using Ontap_Net104_319.Models;

namespace Ontap_Net104_319.Controllers
{
    public class CartController : Controller
    {
        AppDbContext _context;
        public CartController()
        {
            _context = new AppDbContext();
        }
        public IActionResult Index() // Hiển thị tất cả danh sách các sản phẩm có trong giỏ hàng của 1 user
        {
            // Check xem đã đăng nhập chưa
            var check = HttpContext.Session.GetString("username");
            if (String.IsNullOrEmpty(check)) // chưa đăng nhập => bắt đăng nhập
            {
                return RedirectToAction("Login", "Account");
            }else
            {
                var cartItems = _context.CartDetails.Where(p=>p.Username== check).ToList();
                return View(cartItems); // truyền dữ liệu lấy được sang bên view
            } 
        }
    }
}
