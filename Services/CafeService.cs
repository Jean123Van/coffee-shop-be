using CoffeeNoteBe.DTO.Cafe;
using CoffeeNoteBe.Interfaces;

namespace CoffeeNoteBe.Services;

public class CafeService
{

    private readonly ICafeRepository _cafeRepository;

    public CafeService(ICafeRepository cafeRepository)
    {
        _cafeRepository = cafeRepository;
    }

    public async Task<string> AddNewCafe(AddNewCafeRequest addNewCafeRequest)
    {

        return await _cafeRepository.Add();
    }
}