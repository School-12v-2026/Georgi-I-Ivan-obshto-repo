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
}
