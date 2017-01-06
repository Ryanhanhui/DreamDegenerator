using PetaPoco;
using SqlServerCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamDegenerator.Controllers.Manager
{
    public class WeChatSetController : Controller
    {
        Database db = new PetaPoco.Database("SqlServerCon");
        static string currentindex = "";
        //
        // GET: /WeChatSet/
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
            var result = db.Page<WeChat_Account>(long.Parse(currentindex), long.Parse(pagesize),
                "select * from WeChat_Account order by Id");
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
        [Authorize]
        public string LoadData(string id)
        {
            var result = db.SingleOrDefault<WeChat_Account>("SELECT * FROM WeChat_Account WHERE Id=@0", id);
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
        [Authorize]
        public string AddData(string AccountNo, string AppId, string Secret, string Description, string Status, string Remark)
        {
            WeChat_Account item = new WeChat_Account();
            item.AccountNo = AccountNo;
            item.AppId = AppId;
            item.Secret = Secret;
            item.Description = Description;
            item.Status = Status;
            item.Remark = Remark;
            //try
            //{
                if (!db.Exists<WeChat_Account>("AccountNo=@0", AccountNo))
                {
                    db.Insert(item);
                    return "添加成功";
                }
                else
                    return "微信账号已经存在，添加失败";
            //}
            //catch (Exception)
            //{
            //    return "添加失败";
            //}
        }
        [Authorize]
        public string UpdateData(string Id, string AccountNo, string AppId, string Secret, string Description, string Status, string Remark)
        {
            WeChat_Account item = new WeChat_Account();
            item.Id = int.Parse(Id);
            item.AccountNo = AccountNo;
            item.AppId = AppId;
            item.Secret = Secret;
            item.Description = Description;
            item.Status = Status;
            item.Remark = Remark;
            try
            {
                WeChat_Account result = db.SingleOrDefault<WeChat_Account>("SELECT * FROM WeChat_Account WHERE Id=@0", Id);
                if(result.AccountNo!=AccountNo)
                {
                    if (!db.Exists<WeChat_Account>("AccountNo=@0", AccountNo))
                    {
                        db.Update(item);
                        return "更新成功";
                    }
                    else
                        return "与其他微信号冲突，请更换";
                }
                else
                {
                    db.Update(item);
                    return "更新成功";
                }                
            }
            catch (Exception)
            {
                return "更新失败";
            }
        }
        [Authorize]
        public string DeleteData(string Id)
        {
            try
            {
                int result = db.Delete("WeChat_Account", "Id", null, Id);
                if (result > 0)
                    return "删除成功";
                else
                    return "删除失败";
            }
            catch (Exception)
            {
                return "删除失败";
            }
        }
    }
}
