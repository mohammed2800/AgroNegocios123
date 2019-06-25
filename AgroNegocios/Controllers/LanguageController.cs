using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AgroNegocios.Controllers
{
    public class LanguageController : Controller
    {
        /// <summary>
        /// Change Language
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpPost]
        public void Change(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

            //es (es-ES) - Espanol
            //en - English

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);
        }
    }
}