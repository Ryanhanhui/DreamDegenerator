using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;

namespace DreamDegenerator.Controllers.Manager
{
    public class WebPageController : Controller
    {
        string tableName, currPage,actionName,strWhere;
        Database db = new PetaPoco.Database("SqlServerCon");
        //
        // GET: /WebPage/
        [Authorize]
        public ActionResult PageInfo(string tablename,string currentpage,string actionname,string strwhere)
        {
            //do something
            tableName = tablename;
            currPage = currentpage;
            actionName = actionname;
            strWhere = strwhere;
            return PartialView();
        }
        public string InitPage()
        {
            long result = db.ExecuteScalar<long>("select count(1) from @0 @1",tableName,strWhere);

            return "";
        }
        public class PageInfo 
        {
            public int pagenum;
            public int currentpage;
            public string pageaction;
        }
    }
}
