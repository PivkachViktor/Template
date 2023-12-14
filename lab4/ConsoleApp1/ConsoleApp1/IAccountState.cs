using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IAccountState
    {
        void UseInternet(int megabytes);
        void MakeCall(int minutes, string number);
    }
}
