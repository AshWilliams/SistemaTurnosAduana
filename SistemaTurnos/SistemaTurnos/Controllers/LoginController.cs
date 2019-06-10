using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaTurnos.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult Login(string usuario,string password)
        {
            Dictionary<string,string> response = new Dictionary<string, string>();
            Session["autorizado"] = false;
            if(usuario.Equals("admin") && password.Equals("admin"))
            {
                response.Add("mensaje","true");
                Session["autorizado"] = true;
            }
            else
            {
                response.Add("mensaje", "false");
            }
            return Json(response);
        }
    }
}