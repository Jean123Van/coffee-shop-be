using CoffeeNoteBe.Models;

namespace CoffeeNoteBe.Interfaces;

public interface ICafeRepository
{
    Task<string> Add(Cafe cafe);
}