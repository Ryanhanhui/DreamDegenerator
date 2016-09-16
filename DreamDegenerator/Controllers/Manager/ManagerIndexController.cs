using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DreamDegenerator.Controllers.Manager
{
    public class ManagerIndexController : Controller
    {
        //
        // GET: /ManagerIndex/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("~/Views/ManagerLogin/Login.cshtml");
        }
        [Authorize]
        public ActionResult DashBoardPage()
        {
            return View();
        }
    }
}
