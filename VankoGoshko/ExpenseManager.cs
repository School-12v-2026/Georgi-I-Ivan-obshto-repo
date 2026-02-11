using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class ExpenseManager
{
    private List<Expense> expenses = new List<Expense>();
    private int nextId = 1;
    private string filePath = "expenses.txt";

    public ExpenseManager()
    {
        LoadFromFile();
    }

    // -----------------------------
    // ADD
    // -----------------------------
    public void AddExpense(decimal amount, string category, DateTime date)
    {
        expenses.Add(new Expense
        {
            Id = nextId++,
            Amount = amount,
            Category = category,
            Date = date
        });
    }

    // -----------------------------
    // GET ALL
    // -----------------------------
    public List<Expense> GetAll()
    {
        return expenses;
    }

    // -----------------------------
    // DELETE
    // -----------------------------
    public bool DeleteExpense(int id)
    {
        var expense = expenses.FirstOrDefault(e => e.Id == id);

        if (expense != null)
        {
            expenses.Remove(expense);
            return true;
        }

        return false;
    }

    // -----------------------------
    // STATISTICS
    // -----------------------------
    public decimal GetTotalSpent()
    {
        return expenses.Sum(e => e.Amount);
    }

    public Expense GetMaxExpense()
    {
        return expenses
            .OrderByDescending(e => e.Amount)
            .FirstOrDefault();
    }

    public decimal GetAverageExpense()
    {
        if (!expenses.Any())
            return 0;

        return expenses.Average(e => e.Amount);
    }

    public Dictionary<string, decimal> GetByCategory()
    {
        return expenses
            .GroupBy(e => e.Category)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(e => e.Amount)
            );
    }

    // -----------------------------
    // SORTING
    // -----------------------------
    public List<Expense> SortByAmount()
    {
        return expenses
            .OrderBy(e => e.Amount)
            .ToList();
    }

    public List<Expense> SortByDate()
    {
        return expenses
            .OrderBy(e => e.Date)
            .ToList();
    }

    public List<Expense> SortByCategory()
    {
        return expenses
            .OrderBy(e => e.Category)
            .ToList();
    }

    // -----------------------------
    // FILE SAVE
    // -----------------------------
    public void SaveToFile()
    {
        var lines = expenses.Select(e =>
            $"{e.Id}|{e.Amount}|{e.Category}|{e.Date:yyyy-MM-dd}"
        );

        File.WriteAllLines(filePath, lines);
    }

    // -----------------------------
    // FILE LOAD
    // -----------------------------
    public void LoadFromFile()
    {
        if (!File.Exists(filePath))
            return;

        var lines = File.ReadAllLines(filePath);

        expenses.Clear();

        foreach (var line in lines)
        {
            var parts = line.Split('|');

            if (parts.Length != 4)
                continue;

            expenses.Add(new Expense
            {
                Id = int.Parse(parts[0]),
                Amount = decimal.Parse(parts[1]),
                Category = parts[2],
                Date = DateTime.Parse(parts[3])
            });
        }

        if (expenses.Any())
            nextId = expenses.Max(e => e.Id) + 1;
    }
}
