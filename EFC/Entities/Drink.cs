using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Entities;

public class Drink
{
    [Key] public string Name { get; set; } = null!;
    public double Price { get; set; }
    public double AlcoholPercentage { get; set; }
    public bool IncludesUmbrella { get; set; }
    
    public int MenuId { get; set; }
    [ForeignKey("MenuId")] public DrinksMenu Menu { get; set; } = null!;

    private Drink()
    {
        
    }

    public Drink(string Name, double Price, double AlcoholPercentage, bool IncludesUmbrella)
    {
        this.Name = Name;
        this.Price = Price;
        this.AlcoholPercentage = AlcoholPercentage;
        this.IncludesUmbrella = IncludesUmbrella;
    }
    
    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Alcohol: {AlcoholPercentage}%, Includes Umbrella: {IncludesUmbrella}";
    }

}