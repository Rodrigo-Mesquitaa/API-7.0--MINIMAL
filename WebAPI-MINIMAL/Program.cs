using Microsoft.EntityFrameworkCore;
using WebAPI_MINIMAL.Context;
using WebAPI_MINIMAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>
    (options => options.UseSqlServer(
        "Data Source=NOTERODRIGO\\SQLEXPRESS;Initial Catalog=Car;Integrated Security=True; TrustServerCertificate=True"));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AddCar", async (Car car, Context context) =>
{
    context.Car.Add(car);
    await context.SaveChangesAsync();
});

app.MapPost("DeleteCar/{id}", async (int id, Context context) =>
{
    var carDelete = await context.Car.FirstOrDefaultAsync(c => c.Id == id);
    if (carDelete != null)
    {
        context.Car.Remove(carDelete);
        await context.SaveChangesAsync();
    }
});

app.MapPost("ListCar/{id}", async (int id, Context context) =>
{
   return await context.Car.ToListAsync();

});

app.MapPost("SearchCar/{id}", async (int id, Context context) =>
{
    return await context.Car.FirstOrDefaultAsync(c => c.Id == id);

});

app.UseSwaggerUI();

app.Run();
