using Scalar.AspNetCore;

namespace OllamaGate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHealthChecks();

        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapOpenApi();
        app.MapScalarApiReference();
        
        app.MapReverseProxy();


        app.MapHealthChecks("/health");
        app.Run();
    }
}