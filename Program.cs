using FutApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=futebol.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

// A documentação só valera para ambiente de desenvolvimento 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
app.MapPost("/times", async (AppDbContext db, Time newEquip) =>
{
    db.Times.Add(newEquip);
    await db.SaveChangesAsync();
    return Results.Created($"O Time {newEquip.Nome} escalado com sucesso!", newEquip);
});

// PUT
app.MapPut("/times/{id}", async (int id, Time updatedEquipe, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time não encontrado");

    time.Nome = updatedEquipe.Nome;
    time.Cidade = updatedEquipe.Cidade;
    time.TitulosBrasileiros = updatedEquipe.TitulosBrasileiros;
    time.TitulosMundiais = updatedEquipe.TitulosMundiais;

    await db.SaveChangesAsync();
    return Results.Ok(time);
});

// DELETE
app.MapDelete("/times/{id}", async (int id, AppDbContext db) =>
{
    var time = await db.Times.FindAsync(id);
    if (time is null) return Results.NotFound("Time não encontrado");

    db.Times.Remove(time);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
