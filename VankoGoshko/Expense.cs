// Expense.cs
using System;

public class Expense
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"{Id}. {Amount:F2} лв | {Category} | {Date:yyyy-MM-dd}";
    }
}
