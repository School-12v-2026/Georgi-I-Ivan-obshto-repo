// ExpenseManager.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class ExpenseManager
{
    private List<Expense> expenses = new List<Expense>();
    private int nextId = 1;

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

    public List<Expense> GetAll()
    {
        return expenses;
    }

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
    public decimal GetTotalSpent()
    {
        return expenses.Sum(e => e.Amount);
    }

    public Expense GetMaxExpense()
    {
        return expenses.OrderByDescending(e => e.Amount).FirstOrDefault();
    }

    public decimal GetAverageExpense()
    {
        if (!expenses.Any()) return 0;
        return expenses.Average(e => e.Amount);
    }

    public Dictionary<string, decimal> GetByCategory()
    {
        return expenses
            .GroupBy(e => e.Category)
            .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
    }

    public List<Expense> SortByAmount()
    {
        return expenses.OrderBy(e => e.Amount).ToList();
    }

    public List<Expense> SortByDate()
    {
        return expenses.OrderBy(e => e.Date).ToList();
    }

    public List<Expense> SortByCategory()
    {
        return expenses.OrderBy(e => e.Category).ToList();
    }

}
