using System;
using System.Collections.Generic;
using System.Text;
using GreatPizza.Core;

namespace GreatPizza.UniteTests
{
  class ValidationTestCases
  {
    /// <summary>
    /// Valid Get Pizzas methods works correctly
    /// </summary>
    /// <param name="pizzaDescription"></param>
    /// <returns></returns>
    public bool IsValidGetPizzas()
    {
      var dtoPizzas  = GreatPizza.Core.DTOs.Data.Pizzas.Get("");
      //Connection Valid
      if (dtoPizzas.correct)
      {
        if (dtoPizzas.pizzas.Count > 0)
        {
          return true;
        } else
        {
          return false;
        }
      } else
      {
        return false;
      }
    }
    /// <summary>
    /// Valid Get Toppings methods works correctly
    /// </summary>
    /// <param name="pizzaDescription"></param>
    /// <returns></returns>
    public bool IsValidGetToppings()
    {
      var dtoToppings = GreatPizza.Core.DTOs.Data.Toppings.Get("");
      //Connection Valid
      if (dtoToppings.correct)
      {
        if (dtoToppings.toppings.Count > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      else
      {
        return false;
      }
    }
  }
}
