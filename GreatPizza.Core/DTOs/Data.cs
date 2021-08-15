using System;
using System.Collections.Generic;
using System.Text;

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

  }
}
