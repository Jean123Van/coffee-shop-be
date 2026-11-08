using CoffeeNoteBe.Models;

namespace CoffeeNoteBe.Interfaces;

public interface ICafeRepository
{
    Task<int> Add(Cafe cafe);
    Task<Cafe?> GetCafeById(int cafeId);
}