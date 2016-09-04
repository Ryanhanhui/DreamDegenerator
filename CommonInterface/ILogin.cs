using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInterface
{
    public interface ILogin
    {
        bool ManagerSignIn(string username, string pwd);
        bool SignIn(string username, string pwd);
    }
}
