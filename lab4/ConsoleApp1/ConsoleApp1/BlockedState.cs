using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BlockedState : IAccountState
    {
        public void UseInternet(AccountContext account, int megabytes)
        {
            // Логіка для стану "Заблоковано" для використання Інтернету
            Console.WriteLine("Internet access is blocked.");
        }

        public void MakeCall(AccountContext account, int minutes, string number)
        {
            // Логіка для стану "Заблоковано" для здійснення дзвінка
            Console.WriteLine("Calling is blocked.");
        }

        public void CheckPackage(AccountContext account, int data, int minutes)
        {
            // Логіка для перевірки пакету у стані "Заблоковано"
            Console.WriteLine("Package access is blocked.");
        }
    }

}
