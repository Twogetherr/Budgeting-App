using BudgetingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BudgetingApp.Data;

public class BudgetAppDbContext : DbContext
{
    public BudgetAppDbContext(DbContextOptions<BudgetAppDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}