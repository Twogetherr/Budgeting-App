using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace BudgetingApp.Model;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    public string Date { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [Required]
    public string Shop { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
    public float Cost { get; set; }
    
}