using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamDegenerator.Controllers.Manager
{
    public class WebPageController : Controller
    {
        static TPageInfo tpage;
        // GET: /WebPage/
        [Authorize]
        [HttpPost]
        public ActionResult PageInfo(string pagenum,string currentpage,string actionname)
        {
            //do something
            tpage = new TPageInfo();
            tpage.pagenum = int.Parse(pagenum);
            tpage.currentpage = int.Parse(currentpage);
            tpage.actionname = actionname;
            return PartialView();
        }
        [HttpGet]
        public string LoadPageInfo()
        {
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(tpage);
            return json;
        }
        public class TPageInfo
        {
            public int pagenum;
            public int currentpage;
            public string actionname;
        }
    }
}
