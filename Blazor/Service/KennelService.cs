using Blazor.Model;

namespace Blazor.Service;

public class KennelService : IKennelService
{
    public List<Dog> dogs = new();

    public KennelService()
    {
        dogs.AddRange(new List<Dog>
        {
            new Dog {
                Id = 1, Name = "Buddy", Sex = "Male", Breed = "Labrador Retriever",
                ImageUrl = "https://img.freepik.com/free-vector/sitting-brown-puppy-dog-logo-template_1051-3347.jpg",
                Description = "Friendly and energetic",
                ArrivalDate = DateTime.Now.AddDays(-10)
            },
            new Dog
            {
                Id = 2, Name = "Bella", Sex = "Female", Breed = "Poodle",
                ImageUrl = "https://img.freepik.com/free-vector/sitting-brown-puppy-dog-logo-template_1051-3347.jpg",
                Description = "Loyal and loving",
                ArrivalDate = DateTime.Now.AddDays(-5)
            },
            new Dog
            {
                Id = 3, Name = "Charlie", Sex = "Female", Breed = "Beagle",
                ImageUrl = "https://img.freepik.com/free-vector/sitting-brown-puppy-dog-logo-template_1051-3347.jpg",
                Description = "Curious and playful",
                ArrivalDate = DateTime.Now.AddDays(-3)
            },
            new Dog
            {
                Id = 4, Name = "Lucy", Sex = "Female", Breed = "Golden Retriever",
                ImageUrl = "https://img.freepik.com/free-vector/sitting-brown-puppy-dog-logo-template_1051-3347.jpg",
                Description = "Gentle and intelligent",
                ArrivalDate = DateTime.Now.AddDays(-7)
            },
            new Dog
            {
                Id = 5, Name = "Max", Sex = "Male", Breed = "Bulldog",
                ImageUrl = "https://img.freepik.com/free-vector/sitting-brown-puppy-dog-logo-template_1051-3347.jpg",
                Description = "Calm and courageous",
                ArrivalDate = DateTime.Now.AddDays(-2)
            }
        });
    }

    public async Task AddDog(Dog dog)
    {
        dog.ArrivalDate = DateTime.Now;
        dog.Id = dogs.Max(d => d.Id) + 1;
        dogs.Add(dog);
    }

    public async Task<List<Dog>> GetDogs()
    {
        return dogs;
    }
}