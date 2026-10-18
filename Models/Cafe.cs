namespace CoffeeNoteBe.Models;

public class Cafe
{
    public int Id { get; set; }
    public required string CafeName { get; set; }
    public required string Location { get; set; }
    public string AboutUs { get; set; } = string.Empty;

    public int UserCreatorId { get; set; }
    public User? UserCreator { get; set; }

    public bool IsOpenMonday { get; set; }
    public string MondayStart { get; set; } = string.Empty;
    public string MondayEnd { get; set; } = string.Empty;

    public bool IsOpenTuesday { get; set; }
    public string TuesdayStart { get; set; } = string.Empty;
    public string TuesdayEnd { get; set; } = string.Empty;

    public bool IsOpenWednesday { get; set; }
    public string WednesdayStart { get; set; } = string.Empty;
    public string WednesdayEnd { get; set; } = string.Empty;

    public bool IsOpenThursday { get; set; }
    public string ThursdayStart { get; set; } = string.Empty;
    public string ThursdayEnd { get; set; } = string.Empty;

    public bool IsOpenFriday { get; set; }
    public string FridayStart { get; set; } = string.Empty;
    public string FridayEnd { get; set; } = string.Empty;

    public bool IsOpenSaturday { get; set; }
    public string SaturdayStart { get; set; } = string.Empty;
    public string SaturdayEnd { get; set; } = string.Empty;

    public bool IsOpenSunday { get; set; }
    public string SundayStart { get; set; } = string.Empty;
    public string SundayEnd { get; set; } = string.Empty;
}