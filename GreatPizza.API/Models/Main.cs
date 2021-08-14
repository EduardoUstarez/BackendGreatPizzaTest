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
        try
        {
          GreatPizza.Core.DTOs.Data.Pizzas.output dtoPizzas = GreatPizza.Core.DTOs.Data.Pizzas.Get("");

          foreach (var dtopizza in dtoPizzas.pizzas)
          {
            Models.Pizza item = new Models.Pizza();
            item.pizzaid = dtopizza.pizzaid;
            item.description = dtopizza.description;

            response.pizzas.Add(item);
          }

          response.correct = true;
        }
        catch (Exception ex)
        {
          response.correct = false;
          response.message = ex.Message;

        }

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
        try
        {
          GreatPizza.Core.DTOs.Data.Toppings.output dtoToppings = GreatPizza.Core.DTOs.Data.Toppings.Get("");

          foreach (var dtotopping in dtoToppings.toppings)
          {
            Models.Topping item = new Models.Topping();
            item.toppingid = dtotopping.toppingid;
            item.description = dtotopping.description;

            response.toppings.Add(item);
          }

          response.correct = true;
        }
        catch (Exception ex)
        {
          response.correct = false;
          response.message = ex.Message;

        }

        return response;
      }
    }
  }
}
