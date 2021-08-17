using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatPizza.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class MainController : ControllerBase
  {
    private ILog _ILog;

    public MainController()
    {
      _ILog = Log.GetInstance;
    }

    /// <summary>
    /// Method to get a list of pizzas
    /// </summary>
    /// <remarks>
    /// This method get all pizzas registered in the database
    ///</remarks>
    [HttpGet("Getpizzas")]
    public ActionResult<Models.Main.Pizzas.Response> GetPizzas()
    {
      Models.Main.Pizzas.Response response = new Models.Main.Pizzas.Response();
      try
      {
        response = Models.Main.Pizzas.Get();
      } catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
    
      return response;
    }

    /// <summary>
    /// Method to get a list of toppings
    /// </summary>
    /// <remarks>
    /// This method get all toppings registered in the database
    ///</remarks>
    [HttpGet("Gettoppings")]
    public ActionResult<Models.Main.Toppings.Response> GetToppings()
    {
      Models.Main.Toppings.Response response = new Models.Main.Toppings.Response();
      try
      {
        response = Models.Main.Toppings.Get();
      } catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }

    /// <summary>
    /// Method to Get a pizza detail
    /// </summary>
    /// <param name="pizzaid"></param>
    /// <remarks>
    /// This method get an specific detail of a pizza
    /// </remarks>
    [HttpGet("GetPizza/{pizzaid}")]
    public ActionResult<Models.Main.PizzaDetail.Response> GetPizza(long pizzaid)
    {
      Models.Main.PizzaDetail.Response response = new Models.Main.PizzaDetail.Response();
      try
      {
        response = Models.Main.PizzaDetail.Get(pizzaid);
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }

    /// <summary>
    /// Method to Add a pizza
    /// </summary>
    /// <param name="addPizzaRequest"></param>
    /// <remarks>
    /// This method add a pizza to the list of pizzas
    ///</remarks>
    [HttpPost("AddPizza")]
    public ActionResult<Models.Main.Pizzas.Response> AddPizza(Models.Main.AddPizza.Request addPizzaRequest)
    {
      Models.Main.AddPizza.Response responseAdd = new Models.Main.AddPizza.Response();
      Models.Main.Pizzas.Response response = new Models.Main.Pizzas.Response();
      try
      {
        responseAdd = Models.Main.AddPizza.Add(addPizzaRequest.pizzadescription);
        response = Models.Main.Pizzas.Get();

        response.correct = responseAdd.correct;
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }

    /// <summary>
    /// Method to delete a pizza
    /// </summary>
    /// <param name="pizzaid"></param>
    /// <remarks>
    /// This method delete a pizza from the list of pizzas
    ///</remarks>
    [HttpDelete("DeletePizza/{pizzaid}")]
    public ActionResult<Models.Main.Pizzas.Response> DeletePizza(long pizzaid)
    {
      Models.Main.DeletePizza.Response responseDelete = new Models.Main.DeletePizza.Response();
      Models.Main.Pizzas.Response response = new Models.Main.Pizzas.Response();
      try
      {
        responseDelete = Models.Main.DeletePizza.Delete(pizzaid);
        response = Models.Main.Pizzas.Get();

        response.correct = responseDelete.correct;
        
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }




    /// <summary>
    /// Method to add topping to pizza
    /// </summary>
    /// <param name="addToppingPizzaRequest"></param>
    /// <remarks>
    /// This method add a topping to an specific pizza
    ///</remarks>
    [HttpPost("AddToppingToPizza")]
    public ActionResult<Models.Main.PizzaDetail.Response> AddToppingToPizza(Models.Main.AddToppingToPizza.Request addToppingPizzaRequest)
    {
      Models.Main.AddToppingToPizza.Response responseAdd = new Models.Main.AddToppingToPizza.Response();
      Models.Main.PizzaDetail.Response response = new Models.Main.PizzaDetail.Response();
      try
      {
        responseAdd = Models.Main.AddToppingToPizza.Add(addToppingPizzaRequest.pizzaid, addToppingPizzaRequest.toppingid);
        response = Models.Main.PizzaDetail.Get(addToppingPizzaRequest.pizzaid);

        response.correct = responseAdd.correct;
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }




    /// <summary>
    /// Method to delete a topping
    /// </summary>
    /// <param name="toppingid"></param>
    /// <remarks>
    /// This method delete a topping from the list of toppings
    ///</remarks>
    [HttpDelete("DeleteTopping/{toppingid}")]
    public ActionResult<Models.Main.Toppings.Response> DeleteTopping(long toppingid)
    {
      Models.Main.DeleteTopping.Response responseDelete = new Models.Main.DeleteTopping.Response();
      Models.Main.Toppings.Response response = new Models.Main.Toppings.Response();
      try
      {
        responseDelete = Models.Main.DeleteTopping.Delete(toppingid);
        response = Models.Main.Toppings.Get();

        response.correct = responseDelete.correct;
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }



    /// <summary>
    /// Method to Add a topping
    /// </summary>
    /// <param name="addToppingRequest"></param>
    /// <remarks>
    /// This method add a topping to the list of toppings
    ///</remarks>
    [HttpPost("AddTopping")]
    public ActionResult<Models.Main.Toppings.Response> AddTopping(Models.Main.AddTopping.Request addToppingRequest)
    {
      Models.Main.AddTopping.Response responseAdd = new Models.Main.AddTopping.Response();
      Models.Main.Toppings.Response response = new Models.Main.Toppings.Response();
      try
      {
        responseAdd = Models.Main.AddTopping.Add(addToppingRequest.toppingdescription);
        response = Models.Main.Toppings.Get();

        response.correct = responseAdd.correct;
        
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }



    /// <summary>
    /// Method to delete a topping from pizza
    /// </summary>
    /// <param name="deleteToppingFromPizzaRequest"></param>
    /// <remarks>
    /// This method delete a topping from pizza
    ///</remarks>
    [HttpPost("DeleteToppingFromPizza/")]
    public ActionResult<Models.Main.DeleteToppingFromPizza.Response> DeleteToppingFromPizza(Models.Main.DeleteToppingFromPizza.Request deleteToppingFromPizzaRequest)
    {
      Models.Main.DeleteToppingFromPizza.Response response = new Models.Main.DeleteToppingFromPizza.Response();
      Models.Main.PizzaDetail.Response responsePizzaDetail = new Models.Main.PizzaDetail.Response();
      try
      {
        response = Models.Main.DeleteToppingFromPizza.Delete(deleteToppingFromPizzaRequest.pizzaid, deleteToppingFromPizzaRequest.toppingid);
        responsePizzaDetail = Models.Main.PizzaDetail.Get(deleteToppingFromPizzaRequest.pizzaid);
        response.pizzaDetail = responsePizzaDetail.pizzaDetail;
        
      }
      catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
        response.message = "There was an error";
      }
      return response;
    }


  }
}
