﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LimitedServicesState : IAccountState
    {
        public void UseInternet(AccountContext account, int megabytes)
        {
            // Логіка для стану "Обмежені послуги" для використання Інтернету
            if (account.packageConnected && account.remainingData >= megabytes)
            {
                account.remainingData -= megabytes;
                Console.WriteLine($"Used {megabytes} MB from the package. Remaining package data: {account.remainingData} MB");
            }
            else
            {
                Console.WriteLine("Limited Internet access. Please connect a package.");
            }
        }

        public void MakeCall(AccountContext account, int minutes, string number)
        {
            // Логіка для стану "Обмежені послуги" для здійснення дзвінка
            if (account.packageConnected && account.remainingMinutes >= minutes)
            {
                account.remainingMinutes -= minutes;
                Console.WriteLine($"Called {number} for {minutes} minutes from the package. Remaining package minutes: {account.remainingMinutes}");
            }
            else
            {
                Console.WriteLine("Limited calling minutes. Please connect a package.");
            }
        }

        public void CheckPackage(AccountContext account, int data, int minutes)
        {
            // Логіка для перевірки пакету у стані "Обмежені послуги"
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
