// Program.cs
using System;

class Program
{
    static ExpenseManager manager = new ExpenseManager();

    static void Main()
    {
        manager.LoadFromFile();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- МЕНЮ ---");
            Console.ResetColor();

            Console.WriteLine("1. Добави разход");
            Console.WriteLine("2. Покажи всички");
            Console.WriteLine("3. Изтрий разход");
            Console.WriteLine("4. Изход");

            Console.Write("Избор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddExpense(); break;
                case "2": ShowAll(); break;
                case "3": Delete(); break;
                case "4":
                    manager.SaveToFile();
                    return;
            }
        }
    }

    static void AddExpense()
    {
        Console.Write("Сума: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Категория: ");
        string category = Console.ReadLine();

        Console.Write("Дата (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        manager.AddExpense(amount, category, date);
    }

    static void ShowAll()
    {
        foreach (var e in manager.GetAll())
        {
            PrintColoredExpense(e);
        }
    }

    static void Delete()
    {
        Console.Write("ID за изтриване: ");
        int id = int.Parse(Console.ReadLine());

        if (manager.DeleteExpense(id))
            Console.WriteLine("Изтрит успешно!");
        else
            Console.WriteLine("Няма такъв ID.");
    }

    static void PrintColoredExpense(Expense e)
    {
        if (e.Amount > 100)
            Console.ForegroundColor = ConsoleColor.Red;
        else if (e.Amount < 20)
            Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(e);
        Console.ResetColor();
    }
}
