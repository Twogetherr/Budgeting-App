using System.ComponentModel.DataAnnotations;

namespace BudgetingApp.Model;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}