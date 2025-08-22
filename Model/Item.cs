using System.ComponentModel.DataAnnotations;

namespace BudgetingApp.Model;

public class Item
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public float Price { get; set; }
    public int TransactionId { get; set; }
    public Transaction Transaction { get; set; }
}