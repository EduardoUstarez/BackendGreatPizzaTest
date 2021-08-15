using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class MainController : ControllerBase
  {
    /// <summary>
    /// Se usa para probar
    /// </summary>
    [HttpGet]
    public ActionResult<string> postTest()
    {
      return "true";
    }

    /// <summary>
    /// Method to get pizzas
    /// </summary>
    /// <returns>Pizzas</returns>
    [HttpGet("Getpizzas")]
    public ActionResult<Models.Main.Pizzas.Response> GetPizzas()
    {
      Models.Main.Pizzas.Response response = Models.Main.Pizzas.Get();
      return response;
    }

    /// <summary>
    /// Method to get toppings
    /// </summary>
    /// <returns>Toppings</returns>
    [HttpGet("Gettoppings")]
    public ActionResult<Models.Main.Toppings.Response> GetToppings()
    {
      Models.Main.Toppings.Response response = Models.Main.Toppings.Get();
      return response;
    }

    /// <summary>
    /// Method to get toppings
    /// </summary>
    /// <returns>Toppings</returns>
    [HttpDelete("DeletePizza/{id}")]
    public ActionResult<String> DeletePizza(long id)
    {
      return "true";
    }
  }
}
