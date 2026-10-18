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

    public async Task<string> Add(Cafe cafe)
    {
        return "Created cafe successfully";
    }

}