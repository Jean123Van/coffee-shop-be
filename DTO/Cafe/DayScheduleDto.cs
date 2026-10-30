namespace CoffeeNoteBe.DTO.Cafe;

public class DayScheduleDto
{
    public bool IsOpen { get; set; }
    public string Opening { get; set; } = string.Empty;
    public string Closing { get; set; } = string.Empty;
}
