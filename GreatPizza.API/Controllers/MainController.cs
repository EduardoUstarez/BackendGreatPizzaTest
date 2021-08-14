using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MainController : ControllerBase
  {
    [HttpGet]
    [Route("[action]")]
    public ActionResult<string> postTest()
    {
      return "true";
    }

    [HttpGet]
    [Route("[action]")]
    public ActionResult<Models.Main.Pizzas.Response> GetPizzas()
    {
      Models.Main.Pizzas.Response response = Models.Main.Pizzas.Get();
      return response;
    }

    [HttpGet]
    [Route("[action]")]
    public ActionResult<Models.Main.Toppings.Response> GetToppings()
    {
      Models.Main.Toppings.Response response = Models.Main.Toppings.Get();
      return response;
    }
  }
}
