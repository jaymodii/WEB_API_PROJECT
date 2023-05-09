using PizzaStore.DB;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Entity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => { });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "First API", Description = "Pizzas are Delicious.", Version = "v1" }));
var app = builder.Build();
app.UseRouting();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API v1"));

app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapPost("/pizzas/",(Pizza pizza)=>PizzaDB.CreatePizza(pizza));
app.MapGet("/pizzas/", () => PizzaDB.GetPizzas());
app.MapPut("/pizzas/",(Pizza pizza)=>PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));
app.Run();
