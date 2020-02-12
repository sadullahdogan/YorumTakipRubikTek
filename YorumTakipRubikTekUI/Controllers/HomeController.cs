
using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YorumTakipRubikTekUI.Utility;

namespace YorumTakipRubikTekUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext db = new DatabaseContext();
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            
            return View(db.Yorumlar.ToList());
        }
        public ActionResult YorumEkle() {
            return View();
        }
        [HttpPost]
        public ActionResult YorumEkle(Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                var kelimeList = db.YasakliKelimeler.ToList();
               yorum.İcerik= yorum.İcerik.YasakKontrol(kelimeList);
               
                yorum.Kullanici = User.Identity.Name;
                yorum.Tarih = DateTime.Now;
                db.Yorumlar.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}