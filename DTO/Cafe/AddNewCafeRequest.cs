using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CoffeeNoteBe.DTO.Cafe;

public record AddNewCafeRequest(
    [Required] string CafeName,
    [Required] string CafeAddress,
    string? CafeAboutUs = null,
    string? CafeSchedule = null,
    List<IFormFile>? Images = null
)
{
    public int UserCreatorId { get; set; }
}