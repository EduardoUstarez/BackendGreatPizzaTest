using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatPizza.Core;

namespace GreatPizza.API.Models
{
  public class Main
  {
    public class Pizzas
    {
      public class Request
      {
      }
      public class Response : Models.Common
      {
        public List<Models.Pizza> pizzas { get; set; } = new List<Models.Pizza>();
      }
      public static Response Get()
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.Pizzas.output dtoPizzas = GreatPizza.Core.DTOs.Data.Pizzas.Get("");

        foreach (var dtopizza in dtoPizzas.pizzas)
        {
          Models.Pizza item = new Models.Pizza();
          item.pizzaid = dtopizza.pizzaid;
          item.description = dtopizza.description;

          response.pizzas.Add(item);
        }

        response.correct = true;



        return response;
      }


    }

    public class Toppings
    {
      public class Request
      {
      }
      public class Response : Models.Common
      {
        public List<Models.Topping> toppings { get; set; } = new List<Models.Topping>();
      }
      public static Response Get()
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.Toppings.output dtoToppings = GreatPizza.Core.DTOs.Data.Toppings.Get("");

        foreach (var dtotopping in dtoToppings.toppings)
        {
          Models.Topping item = new Models.Topping();
          item.toppingid = dtotopping.toppingid;
          item.description = dtotopping.description;

          response.toppings.Add(item);
        }

        response.correct = true;


        return response;
      }
    }


    public class PizzaDetail
    {
      public class Request
      {
      }
      public class Response : Models.Common
      {
        public Models.Pizza pizzaDetail { get; set; } = new Models.Pizza();
      }
      public static Response Get(long pizzaid)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.PizzaDetail.output dtoPizzaDetail = GreatPizza.Core.DTOs.Data.PizzaDetail.Get(pizzaid);

        response.pizzaDetail.pizzaid = dtoPizzaDetail.pizzaDetail.pizzaid;
        response.pizzaDetail.description = dtoPizzaDetail.pizzaDetail.description;

        foreach (var item in dtoPizzaDetail.pizzaDetail.toppings)
        {
          Models.Topping topping = new Models.Topping();
          topping.toppingid = item.toppingid;
          topping.description = item.description;
          response.pizzaDetail.toppings.Add(topping);
        }

        response.correct = true;

        return response;
      }

    }


    public class DeletePizza
    {
      public class Request
      {
      }
      public class Response : Models.Common
      {
      }
      public static Response Delete(long pizzaid)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.PizzaDelete.output dtoPizzaDelete = GreatPizza.Core.DTOs.Data.PizzaDelete.Delete(pizzaid);

        response.correct = dtoPizzaDelete.correct;
        response.message = dtoPizzaDelete.message;

        return response;
      }
    }



    public class AddPizza
    {
      public class Request
      {
        public string pizzadescription { get; set; }
      }
      public class Response : Models.Common
      {
      }
      public static Response Add(string pizzadescription)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.AddPizza.output dtoAddPizza = GreatPizza.Core.DTOs.Data.AddPizza.Add(pizzadescription);

        response.correct = dtoAddPizza.correct;
        response.message = dtoAddPizza.message;

        return response;
      }
    }


    public class AddToppingToPizza
    {
      public class Request
      {
        public long pizzaid { get; set; }
        public long toppingid { get; set; }
      }
      public class Response : Models.Common
      {
      }
      public static Response Add(long pizzaid, long toppingid)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.AddToppingToPizza.output dtoAddToppingToPizza = GreatPizza.Core.DTOs.Data.AddToppingToPizza.Add(pizzaid, toppingid);

        response.correct = dtoAddToppingToPizza.correct;
        response.message = dtoAddToppingToPizza.message;

        return response;
      }
    }


    public class DeleteTopping
    {
      public class Request
      {
      }
      public class Response : Models.Common
      {
      }
      public static Response Delete(long toppingid)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.DeleteTopping.output dtoDeleteTopping = GreatPizza.Core.DTOs.Data.DeleteTopping.Delete(toppingid);

        response.correct = dtoDeleteTopping.correct;
        response.message = dtoDeleteTopping.message;

        return response;
      }
    }



    public class AddTopping
    {
      public class Request
      {
        public string toppingdescription { get; set; }
      }
      public class Response : Models.Common
      {
      }
      public static Response Add(string toppingdescription)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.AddTopping.output dtoAddTopping = GreatPizza.Core.DTOs.Data.AddTopping.Add(toppingdescription);

        response.correct = dtoAddTopping.correct;
        response.message = dtoAddTopping.message;

        return response;
      }
    }



    public class DeleteToppingFromPizza
    {
      public class Request
      {
        public long pizzaid { get; set; }
        public long toppingid { get; set; }
      }
      public class Response : Models.Common
      {
        public Models.Pizza pizzaDetail { get; set; } = new Models.Pizza();
      }
      public static Response Delete(long pizzaid, long toppingid)
      {
        Response response = new Response();

        GreatPizza.Core.DTOs.Data.DeleteToppingFromPizza.output dtoToppingFromPizza = GreatPizza.Core.DTOs.Data.DeleteToppingFromPizza.Delete(pizzaid, toppingid);

        response.correct = dtoToppingFromPizza.correct;
        response.message = dtoToppingFromPizza.message;

        return response;
      }
    }



  }
}
