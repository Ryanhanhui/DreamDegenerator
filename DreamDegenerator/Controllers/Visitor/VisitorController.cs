using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonInterface;

namespace DreamDegenerator.Controllers.Visitor
{
    public class VisitorController : Controller
    {
        //
        // GET: /Visitor/

        public ActionResult Index()
        {
            return View();
        }
        
        public string Init()
        {
            string jsondata = "";
            IVisitor ivisitor = new DreamDegenerator.Models.Visitor.Visitor();
            jsondata = ivisitor.GetNavigationList();
            return jsondata;
        }
    }
}
