using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PJC.Models;

namespace PJC.Controllers
{
    public class MuaSachController : Controller
    {
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            return View(context.GetMuaSach());
        }
        [HttpPost]

        public IActionResult Xoa(int id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            context.XoaDonHangMuaSach(id);
            return Redirect("./");

        }
        [HttpPost]
        public IActionResult Ban(int id,string MaSach)
        {
            string user = HttpContext.Session.GetString("user");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            context.BanDonHangMuaSach(id, MaSach,user);

            return Redirect("./");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.sessionv = HttpContext.Session.GetString("user");
            return View();
        }
        [HttpPost]
        public IActionResult Create(muasach muasachs)
        {
            string user = HttpContext.Session.GetString("user");
            muasachs.NguoiBan = user;
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.CreateMuaSach(muasachs);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới không thành công";
            }
            return RedirectToAction("Index");
        }
    }
}
