using FutApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=futebol.db"));

var app = builder.Build();

// GET
app.MapGet("/times", async (AppDbContext db) =>
{
    return await db.Times.ToListAsync();
});

// GET por Id
app.MapGet("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);

    return time != null
    ? Results.Ok(time)
    : Results.NotFound("Time não encontrado");
});

// POST
app.MapPost("/times", async (AppDbContext db, Time newTime) =>
{
    db.Times.Add(newTime);
    await db.SaveChangesAsync();
    return Results.Created($"O Time {newTime.Nome} escalado com sucesso!", newTime);
});

app.Run();
