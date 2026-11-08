using CoffeeNoteBe.Data;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeNoteBe.Repositories;

public class CafeRepository : ICafeRepository
{

    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Cafe> _cafes;

    public CafeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _cafes = appDbContext.Cafes;
    }

    public async Task<int> Add(Cafe cafe)
    {
        _cafes.Add(cafe);
        return await _appDbContext.SaveChangesAsync();


    }

    public async Task<Cafe?> GetCafeById(int cafeId)
    {
        var cafe = await _cafes.FindAsync(cafeId);
        return cafe;
    }

}