using System.Text.Json;

namespace Ollyware.Flowlly.Core.API.Domain.Extensions;

public static class JsonHelpers
{
    public static string? GetValueFromJson(this string body, string key)
    {
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>
            (
                body,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                }
            );

        if (jsonObject is not null && jsonObject.Count > 0)
            return jsonObject.ContainsKey(key) ? jsonObject[key].ToString() : null;
        else
            return null;
    }
}
