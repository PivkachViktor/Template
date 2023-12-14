using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AccountContext
    {
        private IAccountState currentState;
        private double balance;
        private bool packageConnected;
        private int remainingData; // Кількість Мб, які залишилися в пакеті
        private int remainingMinutes; // Кількість хвилин, які залишилися в пакеті

        public AccountContext()
        {
            // Початковий стан абонента (можна встановити по замовчуванню)
            currentState = new EnoughFundsState(); // Наприклад, початковий стан - "Достатньо коштів"
            balance = 200; // Приклад початкового балансу
            packageConnected = false;
            remainingData = 0;
            remainingMinutes = 0;
        }

        // Метод для підключення пакету послуг
        public void ConnectPackage(int data, int minutes)
        {
            if (balance >= 145) // Перевірка наявності коштів для підключення пакету
            {
                remainingData = data;
                remainingMinutes = minutes;
                packageConnected = true;
                balance -= 145; // Оплата пакету, якщо вартість фіксована (додайте перевірку, якщо вартість пакету може змінюватися)
                Console.WriteLine($"Package connected! You have {data} MB and {minutes} minutes available.");
            }
            else
            {
                Console.WriteLine("Insufficient funds to connect the package.");
            }
        }
        public double GetBalance()
        {
            return balance;
        }

        public void ChangeState(IAccountState newState)
        {
            currentState = newState;
        }

        public void UseInternet(int megabytes)
        {
            if (packageConnected && remainingData >= megabytes)
            {
                remainingData -= megabytes;
                Console.WriteLine($"Used {megabytes} MB from the package. Remaining package data: {remainingData} MB");
            }
            else
            {
                if (balance >= 7) // Приклад: пакет 200 МБ за 7 грн
                {
                    balance -= 7;
                    Console.WriteLine("Paid 7 UAH for 200 MB daily Internet package.");
                    remainingData = 200;
                    Console.WriteLine("Used 200 MB from the daily package.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }

        public void MakeCall(int minutes, string number)
        {
            double callCost = minutes * 0.60;

            if (packageConnected && remainingMinutes >= minutes)
            {
                remainingMinutes -= minutes;
                Console.WriteLine($"Called {number} for {minutes} minutes from the package. Remaining package minutes: {remainingMinutes}");
            }
            else
            {
                if (balance >= callCost)
                {
                    balance -= callCost;
                    Console.WriteLine($"Paid {callCost} UAH for the call to {number}.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }
    }


}
