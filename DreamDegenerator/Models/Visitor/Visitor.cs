using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonInterface;
using PetaPoco;
using SqlServerCon;

namespace DreamDegenerator.Models.Visitor
{
    public class Visitor : IVisitor
    {
        Database db = new PetaPoco.Database("SqlServerCon");
        public string GetNavigationList()
        {
            var navigation = db.Query<NavigationConfig>("select * from NavigationConfig where Status='1'");
            System.Web.Script.Serialization.JavaScriptSerializer jsS = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = "";
            json = jsS.Serialize(navigation);
            return json;
        }
    }
}