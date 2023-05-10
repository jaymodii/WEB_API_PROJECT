namespace PizzaStore.DB;
using Entity.Data;
using Entity.Models;
//public record Pizza
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//}

public class PizzaDB
{
   // private static List<Pizza> _pizzas = new List<Pizza>()
   //{
   //  new Pizza{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
   //  new Pizza{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
   //  new Pizza{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"}
   //};


    private readonly PizzaDbContext _context;
    public PizzaDB(PizzaDbContext db)
    {
        _context = db;
    }

    public List<PizzaInfo> GetPizzas()
    {
        List<PizzaInfo> pizzas = _context.PizzaInfos.ToList();
        return pizzas;
    }

    public PizzaInfo? GetPizza(int id)
    {
        return _context.PizzaInfos.SingleOrDefault(pizza => pizza.Id == id);
    }

    public PizzaInfo CreatePizza(PizzaInfo pizza)
    {
        PizzaInfo p = new PizzaInfo();

        p.Name = pizza.Name;
        p.Description = pizza.Description;
        p.Id = pizza.Id;
        _context.PizzaInfos.Add(p);
        _context.SaveChanges();
        return p;
    }

    public PizzaInfo? UpdatePizza(PizzaInfo update)
    {
      PizzaInfo? pizza=_context.PizzaInfos.Find(update.Id);
    if(pizza != null)
        {
            pizza.Name = update.Name;
            pizza.Description = update.Description;
            _context.PizzaInfos.Update(pizza);
            _context.SaveChanges();
            return update;
        }
       
            return null;
        
    }

    public void RemovePizza(long id)
    {
        PizzaInfo? pizza = _context.PizzaInfos.Find(id);
        _context.PizzaInfos.Remove(pizza);
        _context.SaveChanges();
    }
}