﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlServerCon;

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
        [Authorize]
        public string LoadData(string id)
        {
            DreamDegenerator.Models.Manage.SystemPlate handle = new Models.Manage.SystemPlate();
            return handle.GetJsonData(id);
        }
        [Authorize]
        public string UpdateData(string Id,string TypeName,string IconName,string Description,string LinkUrl,string Status,string Memo)
        {
            NavigationConfig na = new NavigationConfig();
            na.Id = int.Parse(Id);
            na.TypeName = TypeName;
            na.IconName = IconName;
            na.Description = Description;
            na.LinkUrl = LinkUrl;
            na.Status = Status;
            na.Memo = Memo;
            DreamDegenerator.Models.Manage.SystemPlate handle = new Models.Manage.SystemPlate();
            bool result = handle.UpdateData(na);
            if (result)
                return "保存成功";
            else
                return "保存失败";
        }
        [Authorize]
        public string AddData(string TypeName,string IconName,string Description,string LinkUrl,string Status,string Memo)
        {
            NavigationConfig na = new NavigationConfig();
            na.TypeName = TypeName;
            na.IconName = IconName;
            na.Description = Description;
            na.LinkUrl = LinkUrl;
            na.Status = Status;
            na.Memo = Memo;
            DreamDegenerator.Models.Manage.SystemPlate handle = new Models.Manage.SystemPlate();
            bool result = handle.AddData(na);
            if (result)
                return "添加成功";
            else
                return "添加失败";
        }
        [Authorize]
        public string DeleteData(string Id)
        {
            DreamDegenerator.Models.Manage.SystemPlate handle = new Models.Manage.SystemPlate();
            bool result = handle.DeleteData(Id);
            if (result)
                return "删除成功";
            else
                return "删除失败";
        }
    }
}
