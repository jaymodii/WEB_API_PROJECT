using PizzaStore.DB;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Entity.Data;
using Entity.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
builder.Services.AddCors(options => { });
builder.Services.AddScoped<PizzaDB>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza API", Description = "Pizzas are Delicious.", Version = "v1" }));
var app = builder.Build();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1"));
app.MapGet("/pizzas/{id}", (int id, PizzaDB pizzaDb) =>
{
    var pizza = pizzaDb.GetPizza(id);
    if (pizza != null)
    {
        return pizza;
    }
    else
    {
        return null;
    }
});
app.MapPost("/pizzas/", (PizzaInfo pizza, PizzaDB pizzaDb) =>
{
    var createdPizza = pizzaDb.CreatePizza(pizza);
    return createdPizza;
});
app.MapGet("/pizzas/", (PizzaDB pizzaDb) =>
{
    var pizzas = pizzaDb.GetPizzas();
    return Results.Ok(pizzas);
});
app.MapPut("/pizzas/", (PizzaInfo pizza, PizzaDB pizzaDb) =>
{
    pizzaDb.UpdatePizza(pizza);
    return Results.Ok();
});
app.MapDelete("/pizzas/{id}", (long id, PizzaDB pizzaDb) =>
{
    pizzaDb.RemovePizza(id);
    return Results.Ok();
});
app.Run();
