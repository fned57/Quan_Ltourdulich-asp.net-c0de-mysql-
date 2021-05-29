using Microsoft.AspNetCore.Mvc;
using PJC.Models;

namespace PJC.Areas.PageReview
{
    [Area("PageReview")]
    public class ProductController : Controller
    {
        private StoreContext context;
        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetSanPham());
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            Sach s = context.GetSachByMa(id);
            ViewData.Model = s;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetSanPhamSearch(searchString));
        }
        [HttpPost]
        public IActionResult Detail(string MaSach, string HoTen, string SoDienThoai, string DiaChi)
        {
      
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            muasach a = new muasach();
            a.HoTen = HoTen;
            a.SoDienThoai = SoDienThoai;
            a.DiaChi = DiaChi;
            a.MaSach = MaSach;
            a.TinhTranDon = 0;
            a.TinhTranThanhToan = 0;
            a.NguoiBan = "Khách Hàng";
            context.CreateMuaSach(a);
            return Redirect("../");

        }
    }
}
