using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        AccountContext account = new AccountContext();

        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Використати Інтернет");
            Console.WriteLine("2. Здійснити дзвінок");
            Console.WriteLine("3. Переглянути баланс");
            Console.WriteLine("4. Підключити пакет послуг");
            Console.WriteLine("5. Вийти");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть кількість МБ для використання Інтернету: ");
                        if (int.TryParse(Console.ReadLine(), out int megabytes))
                        {
                            account.UseInternet(megabytes);
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення.");
                        }
                        break;
                    case 2:
                        Console.Write("Введіть тривалість дзвінка (хв): ");
                        if (int.TryParse(Console.ReadLine(), out int minutes))
                        {
                            Console.Write("Введіть номер: ");
                            string number = Console.ReadLine();
                            account.MakeCall(minutes, number);
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення.");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"Ваш поточний баланс: {account.GetBalance()} UAH");
                        break;
                    case 4:
                        Console.WriteLine("Введіть кількість Мб у пакеті:");
                        if (int.TryParse(Console.ReadLine(), out int data))
                        {
                            Console.WriteLine("Введіть кількість хвилин у пакеті:");
                            if (int.TryParse(Console.ReadLine(), out int inputMinutes)) // Змінено 'minutes' на 'inputMinutes'
                            {
                                account.ConnectPackage(data, inputMinutes);
                            }
                            else
                            {
                                Console.WriteLine("Некоректне значення хвилин.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректне значення Мб.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("До побачення!");
                        return;
                    
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некоректний ввід.");
            }
        }
    }
}
