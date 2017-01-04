using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamDegenerator.Controllers.Manager
{
    public class WeChatSetController : Controller
    {
        static string currentindex = "";
        //
        // GET: /WeChatSet/

        public ActionResult Index(int id)
        {
            currentindex = id.ToString();
            return View();
        }

    }
}
