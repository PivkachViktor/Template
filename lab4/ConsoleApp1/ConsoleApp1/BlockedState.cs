using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BlockedState : IAccountState
    {
        public void UseInternet(int megabytes)
        {
            // Логіка використання Інтернету для стану 
        }

        public void MakeCall(int minutes, string number)
        {
            // Логіка здійснення дзвінка для стану 
        }
    }
}
