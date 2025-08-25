using System.Transactions;
using BudgetingApp.Model;

namespace BudgetingApp.Data;

public interface IBudgetAppRepo
{
    public IEnumerable<Model.Transaction> GetAllTransactions();
    public IEnumerable<Model.Transaction> GetTransactions(int num);
    public IEnumerable<Item> GetItems(Model.Transaction transaction);
    public float CalculateCost(IEnumerable<Item> items);
    public Category AddCategory(Category category);
    public Model.Transaction AddTransaction(Model.Transaction transaction);
    public Item AddItem(Item item);
}