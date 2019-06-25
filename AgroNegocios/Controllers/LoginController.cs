using AgroNegocios.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgroNegocios.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users User)
        {
            AgroNegociosEntities entity = new AgroNegociosEntities();
            var user = entity.Users.Where(x => x.UserName == User.UserName && x.Password == User.Password).FirstOrDefault();

            TempData["succ"] = false;

            if (user == null)
            {
                TempData["msg"] = "פרטים שגויים";
                return View();
            }

            var cookie = new HttpCookie("UserModel");
            cookie.Values["ID"] = DecryptString(user.ID.ToString());
            cookie.Values["UserName"] = DecryptString(user.UserName);
            cookie.Values["Password"] = DecryptString(user.Password);
            cookie.Expires = DateTime.Now.AddMinutes(30);
            Response.Cookies.Add(cookie);
            Session["fullName"] = user.FullName;

            return RedirectToAction("Index","Admin");
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["UserModel"];
            if (cookie != null && cookie.Value != null)
                Response.Cookies["UserModel"].Expires = DateTime.Now.AddDays(-1);

            return View("Index");
        }

        private string DecryptString(string value)
        {
            var BytesArray = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(MachineKey.Protect(BytesArray, "ProtectCookie"));
        }
    }
}