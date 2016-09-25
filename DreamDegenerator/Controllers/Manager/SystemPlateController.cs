using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamDegenerator.Controllers.Manager
{
    public class SystemPlateController : Controller
    {
        static string currentindex = "";
        // GET: /SystemPlate/
        [Authorize]
        public ActionResult List(int id)
        {
            currentindex = id.ToString();
            return View();
        }
        [Authorize]
        [HttpGet]
        public string InitData(string pagesize)//获取数据
        {
            DreamDegenerator.Models.Manage.SystemPlate handle = new Models.Manage.SystemPlate();
            return handle.GetInitJsonData(currentindex, pagesize);
        }
    }
}
