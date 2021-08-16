using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GreatPizza.Core.DTOs
{
  public class Data
  {
    public class Pizzas
    {
      public class input
      {

      }
      public class output : Definition.Common
      {
        public List<Definition.Pizza> pizzas { get; set; } = new List<Definition.Pizza>();
      }

      public static output Get(string _connectionString)
      {
        output response = new output();
 
          using (var context = new Entities.greatpizzaDBContext())
          {

            foreach (var objPizza in context.Pizzas)
            {
              Definition.Pizza item = new Definition.Pizza();
              item.pizzaid = objPizza.Pizzaid;
              item.description = objPizza.Description;

              response.pizzas.Add(item);

            }

            response.correct = true;
          }
        
        return response;
      }
    }


    public class Toppings
    {
      public class input
      {

      }
      public class output : Definition.Common
      {
        public List<Definition.Topping> toppings { get; set; } = new List<Definition.Topping>();
      }

      public static output Get(string _connectionString)
      {
        output response = new output();

          using (var context = new Entities.greatpizzaDBContext())
          {

            foreach (var objPizza in context.Toppings)
            {
              Definition.Topping item = new Definition.Topping();
              item.toppingid = objPizza.Toppingid;
              item.description = objPizza.Description;

              response.toppings.Add(item);

            }

            response.correct = true;

          }
        
        return response;
      }
    }


    public class PizzaDetail
    {
      public class input
      {
        public long pizzaid { get; set; }
      }
      public class output : Definition.Common
      {
        public Definition.Pizza pizzaDetail { get; set; } = new Definition.Pizza();
      }

      public static output Get(long _pizzaid)
      {
        output response = new output();

         
          Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
          Entities.Pizzas PizzaFound = DB.Pizzas.SingleOrDefault(pizza => pizza.Pizzaid == _pizzaid);
          response.pizzaDetail.pizzaid = PizzaFound.Pizzaid;
          response.pizzaDetail.description = PizzaFound.Description;
          var PizzaToppings = DB.Pizzatoppings.Where(pizza => pizza.Pizzaid == _pizzaid).ToList();
          
          foreach (var item in PizzaToppings) 
          {
            Definition.Topping Topping = new Definition.Topping();
            Topping.toppingid = item.Toppingid;
            Topping.description = DB.Toppings.SingleOrDefault(topping => topping.Toppingid == Topping.toppingid).Description;
            response.pizzaDetail.toppings.Add(Topping);
          }
     
        response.correct = true;

        

        return response;
      }
    }


    public class PizzaDelete
    {
      public class input
      {
        public long pizzaid { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Delete(long _pizzaid)
      {
        output response = new output();

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        Entities.Pizzas PizzaFound = DB.Pizzas.SingleOrDefault(pizza => pizza.Pizzaid == _pizzaid);
        DB.Pizzas.Remove(PizzaFound);
        IQueryable<Entities.Pizzatoppings> PizzaToppingsFound = DB.Pizzatoppings.Where(pizza => pizza.Pizzaid == _pizzaid);
        DB.Pizzatoppings.RemoveRange(PizzaToppingsFound);
        DB.SaveChanges();

        response.correct = true;

        return response;
      }
    }

  }
}
