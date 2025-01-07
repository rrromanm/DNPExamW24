using System.ComponentModel.DataAnnotations;

namespace EFC.Entities;

public class DrinksMenu
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public bool ContainsAlcohol { get; set; }
    public TimeOnly AvailableFrom { get; set; }

    public ICollection<Drinks> Drinks { get; set; } = new List<Drinks>();
    
    private DrinksMenu()
    {
        
    }
    
    public DrinksMenu(string name, bool containsAlcohol, TimeOnly availableFroM)
    {
        Name = name;
        ContainsAlcohol = containsAlcohol;
        AvailableFrom = availableFroM;
    }
}