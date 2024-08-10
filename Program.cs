using api_produtos.Domain.Entity;
using api_produtos.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

Batteries.Init();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
