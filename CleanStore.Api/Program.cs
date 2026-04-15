using CleanStore.Application.SharedContext;
using CleanStore.InfraStructure.SharedContext;
using CleanStore.InfraStructure.SharedContext.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    "Server=localhost,1433;Database=cleanstore-dev;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString,
     m => m.MigrationsAssembly("CleanStore.Api")));
builder.Services.AddApplication();
builder.Services.AddInfraStructure();


var app = builder.Build();

app.MapPost("/v1/accounts", async (
    ISender sender,
    CleanStore.Application.AccountContext.UseCases.Create.Command command) =>
{
    var result = await  sender.Send(command);
    return TypedResults.Created($"v1/accounts/{result.Value.Id}", result);
});

app.Run();
