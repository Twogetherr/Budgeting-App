using System.Transactions;
using BudgetingApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BudgetingApp.Data;

public class BudgetAppRepo : IBudgetAppRepo
{
    private readonly BudgetAppDbContext _budgetAppDbContext;
    public IEnumerable<Model.Transaction> GetAllTransactions()
    {
        IEnumerable<Model.Transaction> transactions = _budgetAppDbContext.Transactions.ToList<Model.Transaction>();
        return transactions;
    }

    public IEnumerable<Model.Transaction> GetTransactions(int num)
    {
        int totalTransactions = _budgetAppDbContext.Transactions.Count();
        List<Model.Transaction> transactionList = _budgetAppDbContext.Transactions.ToList<Model.Transaction>();
        if (totalTransactions > num)
        {
            transactionList.RemoveRange(0, totalTransactions - num);
        }
        transactionList.Reverse();
        IEnumerable<Model.Transaction> transactions = transactionList;
        return transactions;
    }

    public IEnumerable<Item> GetItems(Model.Transaction transaction)
    {
        IEnumerable<Item> items = _budgetAppDbContext.Items.Where(i => i.Transaction == transaction);
        return items;
    }

    public float CalculateCost(IEnumerable<Item> items)
    {
        float cost = 0;
        foreach (Item item in items) { cost += item.Price; }
        return cost;
    }

    public Category AddCategory(Category category)
    {
        EntityEntry<Category> e = _budgetAppDbContext.Categories.Add(category);
        Category c = e.Entity;
        _budgetAppDbContext.SaveChanges();
        return c;
    }

    public Model.Transaction AddTransaction(Model.Transaction transaction)
    {
        EntityEntry<Model.Transaction> e = _budgetAppDbContext.Transactions.Add(transaction);
        Model.Transaction t = e.Entity;
        _budgetAppDbContext.SaveChanges();
        return t;
    }

    public Item AddItem(Item item)
    {
        EntityEntry<Item> e = _budgetAppDbContext.Items.Add(item);
        Item i = e.Entity;
        _budgetAppDbContext.SaveChanges();
        return i;
    }

}