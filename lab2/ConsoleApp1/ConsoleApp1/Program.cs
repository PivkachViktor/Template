using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Question> questions = new List<Question>();

        // Додавання питань
        questions.Add(new Question("Яке ваше ім'я?", "string"));
        questions.Add(new Question("Скільки вам років?", "int"));
        questions.Add(new Question("Оберіть кольори: (red/blue/green) ", "вибір зі списку", new List<string> { "red", "blue", "green" }));
        questions.Add(new Question("Яка платформа використовується? (iOS/Android/інше)", "string"));

        // Взаємодія з користувачем
        foreach (var question in questions)
        {
            Console.WriteLine(question.QuestionText);
            string userAnswer = Console.ReadLine();

            if (question.QuestionText.Contains("платформа"))
            {
                if (userAnswer.Equals("iOS", StringComparison.OrdinalIgnoreCase) || userAnswer.Equals("Android", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Помилка: Ця платформа не підтримується.");
                    Console.WriteLine("Все гаразд.");
                    // Можна використовувати винятки для iOS і Android.
                }
                else
                {
                    Console.WriteLine("Все гаразд.");
                }
            }
            else if (question.QuestionType == "int")
            {
                int answer;
                if (int.TryParse(userAnswer, out answer))
                {
                    question.Answer = answer;
                }
                else
                {
                    Console.WriteLine("Помилка: Введіть ціле число.");
                }
            }
            else if (question.QuestionType == "вибір зі списку")
            {
                if (question.AnswerOptions.Contains(userAnswer))
                {
                    question.Answer = userAnswer;
                }
                else
                {
                    Console.WriteLine("Помилка: Неправильний вибір.");
                }
            }
            else
            {
                question.Answer = userAnswer;
            }
        }

        // Виведення результатів
        Console.WriteLine("\nРезультати:");
        foreach (var question in questions)
        {
            if (!question.QuestionText.Contains("платформа"))
            {
                Console.WriteLine($"{question.QuestionText}: {question.Answer}");
            }
        }
    }
}

class Question
{
    public string QuestionText { get; set; }
    public string QuestionType { get; set; }
    public List<string> AnswerOptions { get; set; }
    public object Answer { get; set; }

    public Question(string text, string type, List<string> options = null)
    {
        QuestionText = text;
        QuestionType = type;
        AnswerOptions = options;
    }
}
