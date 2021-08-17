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

          var query = context.Toppings.Where(topping => topping.State == (int) Enumerator.state.Active).ToList();

          foreach (var objTopping in query)
            {
              Definition.Topping item = new Definition.Topping();
              item.toppingid = objTopping.Toppingid;
              item.description = objTopping.Description;

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


    public class AddPizza
    {
      public class input
      {
        public string pizzadescription { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Add(string _pizzadescription)
      {
        output response = new output();

        Entities.Pizzas PizzaToInsert = new Entities.Pizzas()
        {
          Description = _pizzadescription,
        };

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        DB.Pizzas.Add(PizzaToInsert);
        DB.SaveChanges();

        response.correct = true;

        return response;
      }
    }



    public class AddToppingToPizza
    {
      public class input
      {
        public long pizzaid { get; set; }
        public long toppingid { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Add(long _pizzaid, long _toppingid)
      {
        output response = new output();

        Entities.Pizzatoppings ToppgingPizzaToInsert = new Entities.Pizzatoppings()
        {
          Pizzaid = _pizzaid,
          Toppingid = _toppingid,
        };

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        DB.Pizzatoppings.Add(ToppgingPizzaToInsert);
        DB.SaveChanges();

        response.correct = true;

        return response;
      }
    }





    public class DeleteTopping
    {
      public class input
      {
        public long toppingid { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Delete(long _toppingid)
      {
        output response = new output();

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        Entities.Toppings ToppingFound = DB.Toppings.SingleOrDefault(topping => topping.Toppingid == _toppingid);
        ToppingFound.State = (int) Enumerator.state.Inactive;   
        DB.SaveChanges();


        response.correct = true;

        return response;
      }
    }




    public class AddTopping
    {
      public class input
      {
        public string toppingdescription { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Add(string _toppingdescription)
      {
        output response = new output();

        Entities.Toppings ToppingToInsert = new Entities.Toppings()
        {
          Description = _toppingdescription,
          State = (int) Enumerator.state.Active,
        };

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        DB.Toppings.Add(ToppingToInsert);
        DB.SaveChanges();

        response.correct = true;

        return response;
      }
    }





    public class DeleteToppingFromPizza
    {
      public class input
      {
        public long toppingid { get; set; }
      }
      public class output : Definition.Common
      {
      }

      public static output Delete(long _pizzaid, long _toppingid)
      {
        output response = new output();

        Entities.greatpizzaDBContext DB = new Entities.greatpizzaDBContext();
        Entities.Pizzatoppings PizzaToppingFound = DB.Pizzatoppings.SingleOrDefault(pizzatopping => pizzatopping.Pizzaid == _pizzaid && pizzatopping.Toppingid == _toppingid);
        DB.Pizzatoppings.Remove(PizzaToppingFound);
        DB.SaveChanges();

        response.correct = true;

        return response;
      }
    }

  }
}
