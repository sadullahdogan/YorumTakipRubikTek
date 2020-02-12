using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YorumTakipRubikTekUI.Identity;
using YorumTakipRubikTekUI.Models;

namespace YorumTakipRubikTekUI.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUsers> userManager;
        

        public UserController()
        {
            var userStore = new UserStore<ApplicationUsers>(new DataContext());
            userManager = new UserManager<ApplicationUsers>(userStore);
           

        }
        public ActionResult Index() {
            LoginModel user = TempData["User"] as LoginModel;
            
            return View(user);
        }
        public ActionResult GirisYap(string returnUrl) {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else if(!String.IsNullOrEmpty(returnUrl)) {
                ViewBag.ReturnUrl = returnUrl;
            }
            return View();
            
        }
        [HttpPost]
        public ActionResult GirisYap(LoginModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //sistemem kullanıcıyı at //++//ApplicationCookie oluşur sisteme at//
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulunamadı");
                }
            }

            return View(model);
        }
        // GET: User
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(RegisterModel model)
        {
            if (ModelState.IsValid) {
                ApplicationUsers user = new ApplicationUsers();
                var users=userManager.Users.Where(x=>x.UserName.Contains(model.Name + "." + model.Surname)).ToList();
                if (users != null&&users.Count>0)
                {
                    user.UserName = model.Name + "." + model.Surname + "" + users.Count;
                }
                else {
                    user.UserName = model.Name + "." + model.Surname;
                }
                
                user.Name = model.Name;
                user.Surname = model.Surname;
                string sifre = Utility.RastgeleSifre.RandomPassword();
                var result = userManager.Create(user, sifre);//Şifre oluşturulcak rastgele
               
                if (result.Succeeded)
                {
                    LoginModel loginUser = new LoginModel();
                    loginUser.Username = user.UserName;
                    loginUser.Password =sifre;
                    TempData["User"] = loginUser;
                    return RedirectToAction("Index", "User");
                }

            }
            return View();
        }
        public ActionResult CikisYap() {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("GirisYap");
        }
    }
}