using System.Globalization;
using Microsoft.IdentityModel.Tokens;

namespace ProjektNTP.Application.Validators;

public class DateTimeValidator
{
    public static async Task<bool> IsValidDate(DateTime time)
    {
        var timeString = time.ToString(CultureInfo.InvariantCulture);
        return timeString.IsNullOrEmpty() ? await Task.FromResult(false) : await Task.FromResult(true);
    }
}