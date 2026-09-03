using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;

namespace TrimmedWebWorkerInteractiveWebAssembly
{
    [SupportedOSPlatform("browser")]
    public static partial class MyWorker
    {
        [JSExport]
        public static string Greet(string name) => $"Hello, {name}!";
        [JSExport]
        public static string GetUsers()
        {
            var users = new List<User> { new("Alice", 30), new("Bob", 25) };
            return JsonSerializer.Serialize(users);  // Serialize before returning
        }
    }
    public record User(string Name, int Age);
}