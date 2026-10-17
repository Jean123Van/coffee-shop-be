using System.ComponentModel.DataAnnotations;

namespace CoffeeNoteBe.DTO.Cafe;

public record AddNewCafeRequest(
    [Required] string CafeName,
    [Required] string CafeAddress
);