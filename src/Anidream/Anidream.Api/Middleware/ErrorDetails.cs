using System.Text.Json;

namespace Anidream.Api.Extensions.Middleware;

public class ErrorDetails
{
    public int StatusCode { get; set; }   
    public string Message { get; set; }
    public string? InnerMessage { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}