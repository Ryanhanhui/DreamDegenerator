using PetaPoco;
using SqlServerCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamDegenerator.Controllers.Manager
{
    public class WeChatMediaManageController : Controller
    {
        //
        // GET: /WeChatMediaManage/
        Database db = new PetaPoco.Database("SqlServerCon");
        static string currentindex = "";
        [Authorize]
        public ActionResult Index(int id)
        {
            currentindex = id.ToString();
            return View();
        }
        [Authorize]
        [HttpGet]
        public string InitData(string pagesize)//获取数据
        {
            var result = db.Page<WeChat_MediaInfo>(long.Parse(currentindex), long.Parse(pagesize),
                "select * from WeChat_MediaInfo order by Id");
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
        [Authorize]
        public string LoadData(string id)
        {
            var result = db.SingleOrDefault<WeChat_Account>("SELECT * FROM WeChat_MediaInfo WHERE Id=@0", id);
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
        [Authorize]
        public string AddData(string Name, string MediaId, string MediaType, string Prescription,string Remark,string DownUrl)
        {
            return "";
        }
        [Authorize]
        public string UpdateData(string Id, string AccountNo, string AppId, string Secret, string Description, string Status, string Remark)
        {
            return "";
        }
        [Authorize]
        public string DeleteData(string Id)
        {
            return "";
        }
    }
}
