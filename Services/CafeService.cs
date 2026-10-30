using System.Text.Json;
using CoffeeNoteBe.DTO.Cafe;
using CoffeeNoteBe.Interfaces;
using CoffeeNoteBe.Models;

namespace CoffeeNoteBe.Services;

public class CafeService
{
    private readonly ICafeRepository _cafeRepository;

    public CafeService(ICafeRepository cafeRepository)
    {
        _cafeRepository = cafeRepository;
    }

    public async Task<Cafe> AddNewCafe(AddNewCafeRequest addNewCafeRequest)
    {
        var cafe = new Cafe
        {
            CafeName = addNewCafeRequest.CafeName,
            Location = addNewCafeRequest.CafeAddress,
            AboutUs = addNewCafeRequest.CafeAboutUs ?? string.Empty,
            UserCreatorId = addNewCafeRequest.UserCreatorId
        };

        ApplySchedule(cafe, addNewCafeRequest.CafeSchedule);

        await _cafeRepository.Add(cafe);

        return cafe;
    }

    private static void ApplySchedule(Cafe cafe, string? scheduleJson)
    {
        if (string.IsNullOrWhiteSpace(scheduleJson))
        {
            return;
        }


        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var schedules = JsonSerializer.Deserialize<Dictionary<string, DayScheduleDto>>(scheduleJson, options);
        if (schedules == null)
        {
            return;
        }

        var scheduleLookup = new Dictionary<string, DayScheduleDto>(schedules, StringComparer.OrdinalIgnoreCase);

        if (scheduleLookup.TryGetValue("monday", out var monday) && monday.IsOpen)
        {
            cafe.IsOpenMonday = true;
            cafe.MondayStart = monday.Opening ?? string.Empty;
            cafe.MondayEnd = monday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("tuesday", out var tuesday) && tuesday.IsOpen)
        {
            cafe.IsOpenTuesday = true;
            cafe.TuesdayStart = tuesday.Opening ?? string.Empty;
            cafe.TuesdayEnd = tuesday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("wednesday", out var wednesday) && wednesday.IsOpen)
        {
            cafe.IsOpenWednesday = true;
            cafe.WednesdayStart = wednesday.Opening ?? string.Empty;
            cafe.WednesdayEnd = wednesday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("thursday", out var thursday) && thursday.IsOpen)
        {
            cafe.IsOpenThursday = true;
            cafe.ThursdayStart = thursday.Opening ?? string.Empty;
            cafe.ThursdayEnd = thursday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("friday", out var friday) && friday.IsOpen)
        {
            cafe.IsOpenFriday = true;
            cafe.FridayStart = friday.Opening ?? string.Empty;
            cafe.FridayEnd = friday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("saturday", out var saturday) && saturday.IsOpen)
        {
            cafe.IsOpenSaturday = true;
            cafe.SaturdayStart = saturday.Opening ?? string.Empty;
            cafe.SaturdayEnd = saturday.Closing ?? string.Empty;
        }

        if (scheduleLookup.TryGetValue("sunday", out var sunday) && sunday.IsOpen)
        {
            cafe.IsOpenSunday = true;
            cafe.SundayStart = sunday.Opening ?? string.Empty;
            cafe.SundayEnd = sunday.Closing ?? string.Empty;
        }
    }

}
