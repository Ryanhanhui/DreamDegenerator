using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CommonInterface;
using System.Web.Security;

namespace DreamDegenerator.Controllers.Manager
{
    public class ManagerLoginController : Controller
    {
        //
        // GET: /ManagerLogin/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string HandleLogin(string username,string pwd)
        {
            pwd = SHA1_Encrypt(pwd);
            ILogin ilogin = new DreamDegenerator.Models.Login.Login();
            bool result = ilogin.ManagerSignIn(username, pwd);
            if (result)
            {
                Session["Username"] = username;
                FormsAuthentication.SetAuthCookie(username, false);  
                return "/Manager/ManagerIndex/DashBoardPage";
            }
            return "用户名或密码错误";
        }
        /// <summary>
        /// 对字符串进行SHA1加密
        /// </summary>
        /// <param name="Source_String">需要加密的字符串</param>
        /// <returns>密文</returns>
        private string SHA1_Encrypt(string Source_String)
        {
            byte[] StrRes = Encoding.Default.GetBytes(Source_String);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            StrRes = iSHA.ComputeHash(StrRes);
            StringBuilder EnText = new StringBuilder();
            foreach (byte iByte in StrRes)
            {
                EnText.AppendFormat("{0:x2}", iByte);
            }
            return EnText.ToString();
        }

    }
}
