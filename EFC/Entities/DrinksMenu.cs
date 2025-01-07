using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class DrinksMenu
{
    [Key] public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool containsAlcohol { get; set; }
    public TimeOnly AvailableFrom { get; set; }

    public List<Drink> Drinks { get; set; } = [];

    private DrinksMenu()
    {
        
    }
    
    public DrinksMenu (string Name, bool alc, TimeOnly availableFrom)
    {
        this.Name = Name;
        containsAlcohol = alc;
        AvailableFrom = availableFrom;
        Drinks = new List<Drink>();
    }
    
    public override string ToString()
    {
        return $"Name: {Name}, Contains Alcohol: {containsAlcohol}, Available From: {AvailableFrom}, Total Price: {Drinks.Sum(p => p.Price)}";
    }
}