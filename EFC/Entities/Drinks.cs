using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Entities;

public class Drinks
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public double AlcoholPercentage { get; set; }
    public bool IncludesUmbrella { get; set; }
    
    public int DrinksMenuId { get; set; }
    [ForeignKey("DrinksMenuId")] public DrinksMenu DrinksMenu { get; set; }

    private Drinks()
    {
        
    }
    
    public Drinks(string name, double price, double alcoholPercentage, bool includesUmbrella)
    {
        Name = name;
        Price = price;
        AlcoholPercentage = alcoholPercentage;
        IncludesUmbrella = includesUmbrella;
    }
}