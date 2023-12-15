using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IAccountState
    {
        void UseInternet(AccountContext account, int megabytes);
        void MakeCall(AccountContext account, int minutes, string number);
        void CheckPackage(AccountContext account, int data, int minutes);
    }
}
