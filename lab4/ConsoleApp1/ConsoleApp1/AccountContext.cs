using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AccountContext
    {
        public IAccountState currentState;
        public double balance;
        public bool packageConnected;
        public int remainingData;
        public int remainingMinutes;

        // Інші поля і методи
        public double GetBalance()
        {
            
            return balance; // Повернення поточного балансу
        }

        public AccountContext()
        {
            currentState = new EnoughFundsState(); // Змінено на EnoughFundsState як початковий стан
            balance = 200;
            packageConnected = false;
            remainingData = 0;
            remainingMinutes = 0;
        }
        public void UseInternet(int megabytes)
        {
            currentState.UseInternet(this, megabytes);
        }

        public void MakeCall(int minutes, string number)
        {
            currentState.MakeCall(this, minutes, number);
        }

        public void CheckPackage(int data, int minutes)
        {
            currentState.CheckPackage(this, data, minutes);
        }

        public IAccountState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
    }


}
