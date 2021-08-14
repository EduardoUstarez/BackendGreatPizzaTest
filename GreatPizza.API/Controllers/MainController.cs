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
    /// hola
    /// </summary>
    /// <returns>1</returns>
    [HttpGet("Getpizzas")]
    public ActionResult<Models.Main.Pizzas.Response> GetPizzas()
    {
      Models.Main.Pizzas.Response response = Models.Main.Pizzas.Get();
      return response;
    }

    /// <summary>
    /// hola
    /// </summary>
    /// <returns>2</returns>
    //[HttpGet]
    //[Route("[action]")]
    //public ActionResult<Models.Main.Toppings.Response> GetToppings()
    //{
    //  Models.Main.Toppings.Response response = Models.Main.Toppings.Get();
    //  return response;
    //}
  }
}
