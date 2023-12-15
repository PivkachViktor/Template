using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EnoughFundsState : IAccountState
    {
        public void UseInternet(AccountContext account, int megabytes)
        {
            // Логіка для стану "Достатньо коштів" для використання інтернету
            if (account.packageConnected && account.remainingData >= megabytes)
            {
                account.remainingData -= megabytes;
                Console.WriteLine($"Used {megabytes} MB from the package. Remaining package data: {account.remainingData} MB");
            }
            else
            {
                if (account.balance >= 7) // Приклад: пакет 200 МБ за 7 грн
                {
                    account.balance -= 7;
                    Console.WriteLine("Paid 7 UAH for 200 MB daily Internet package.");
                    account.remainingData = 200;
                    Console.WriteLine("Used 200 MB from the daily package.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }

        public void MakeCall(AccountContext account, int minutes, string number)
        {
            // Логіка для стану "Достатньо коштів" для здійснення дзвінка
            double callCost = minutes * 0.60;

            if (account.packageConnected && account.remainingMinutes >= minutes)
            {
                account.remainingMinutes -= minutes;
                Console.WriteLine($"Called {number} for {minutes} minutes from the package. Remaining package minutes: {account.remainingMinutes}");
            }
            else
            {
                if (account.balance >= callCost)
                {
                    account.balance -= callCost;
                    Console.WriteLine($"Paid {callCost} UAH for the call to {number}.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }

        public void CheckPackage(AccountContext account, int data, int minutes)
        {
            // Логіка для перевірки пакету у стані "Достатньо коштів"
            if (account.balance >= 145) // Перевірка наявності коштів для підключення пакету
            {
                account.remainingData = data;
                account.remainingMinutes = minutes;
                account.packageConnected = true;
                account.balance -= 145; // Оплата пакету, якщо вартість фіксована (додайте перевірку, якщо вартість пакету може змінюватися)
                Console.WriteLine($"Package connected! You have {data} MB and {minutes} minutes available.");
            }
            else
            {
                Console.WriteLine("Insufficient funds to connect the package.");
            }
        }
    }

}
