using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Diagnostics;

namespace MyWebWorker;

// Define [JSExport] methods here to run them in a Web Worker.
// Call them from your Blazor app using WebWorkerClient.InvokeAsync.
// Example: await worker.InvokeAsync<string>("MyWebWorker.WorkerMethods.Greet", ["World"]);

[SupportedOSPlatform("browser")]
public static partial class WorkerMethods
{
    [JSExport]
    public static string Greet(string name) => $"Hello, {name}!";

    [JSExport]
    public static void RunWithoutResult()
    {
        Console.WriteLine("Worker void method ran successfully.");
    }

    [JSExport]
    public static void ThrowError()
    {
        throw new InvalidOperationException("Expected exception from the worker.");
    }

    [JSExport]
    public static int SlowComputation(int seconds)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = 0;

        while (stopwatch.Elapsed.TotalSeconds < seconds)
        {
            for (var value = 1; value <= 100_000; value++)
            {
                result = unchecked((result * 31) + value);
            }
        }

        return result;
    }
}
