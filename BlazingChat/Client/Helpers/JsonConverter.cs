using System.Text.Json;

namespace BlazingChat.Client.Helpers
{
    public static class JsonConverter
    {
        public static JsonSerializerOptions JsonSerializerOptions => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static string Serialize(object value, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return JsonSerializer.Serialize(value, jsonSerializerOptions ?? JsonSerializerOptions);
        }

        public static TResult? Deserialize<TResult>(string serialzedString, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            return JsonSerializer.Deserialize<TResult>(serialzedString, jsonSerializerOptions ?? JsonSerializerOptions);
        }
    }
}
