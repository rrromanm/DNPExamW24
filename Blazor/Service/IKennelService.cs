using Blazor.Model;

namespace Blazor.Service;

public interface IKennelService
{
    Task AddDog(Dog dog);
    Task<List<Dog>> GetDogs();
}