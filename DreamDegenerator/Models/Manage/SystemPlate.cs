using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using SqlServerCon;

namespace DreamDegenerator.Models.Manage
{
    public class SystemPlate
    {
        Database db = new PetaPoco.Database("SqlServerCon");
        public SystemPlate() { }
        public string GetInitJsonData(string pageindex,string pagesize)//获取json数据,用于列表显示
        {
            var result = db.Page<NavigationConfig>(long.Parse(pageindex), long.Parse(pagesize),
                "select * from NavigationConfig order by Id");
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
        public bool AddData(NavigationConfig obj)//添加数据
        {
            try
            {
                db.Insert(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateData(NavigationConfig obj)//更新数据
        {
            try
            {
                db.Update(obj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteData(string Id)//删除数据
        {
            try
            {
                int result = db.Delete("NavigationConfig", "Id", null, Id);
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id">数据项id</param>
        /// <returns>json数据格式的查询结果</returns>
        public string GetJsonData(string id)
        {
            var result = db.SingleOrDefault<NavigationConfig>("SELECT * FROM NavigationConfig WHERE Id=@0", id);
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(result);
            return json;
        }
    }
}