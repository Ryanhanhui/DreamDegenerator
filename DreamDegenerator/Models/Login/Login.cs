using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonInterface;
using PetaPoco;

namespace DreamDegenerator.Models.Login
{
    public class Login : ILogin
    {
        Database db = new PetaPoco.Database("SqlServerCon");
        public Login()
        {}
        public bool ManagerSignIn(string username, string pwd)
        {
            long result = db.ExecuteScalar<long>("select dbo.userlogin(@0,@1)", username, pwd);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool SignIn(string username, string pwd)
        {
            return false;
        }
    }
}