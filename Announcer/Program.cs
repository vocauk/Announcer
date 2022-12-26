using Microsoft.AspNetCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        app.MapPost("/", async (ctx) => {
            await ctx.Response.WriteAsync("Hello, world!");
            return;
        });

        app.Run();
    }
}