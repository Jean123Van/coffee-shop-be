using System.ComponentModel.DataAnnotations;

namespace CoffeeNoteBe.DTO.user;

public record LoginRequest(
    [Required] string Email,
    [Required] string Password
);