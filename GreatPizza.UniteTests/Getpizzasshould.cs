using Xunit;

namespace GreatPizza.UniteTests
{
  public class Getpizzasshould
  {
    /// <summary>
    /// Validata pizzas description
    /// </summary>
    [Fact]
    public void ValidateValidPizzas()
    {
      //Arrange
      var pizzaValidator = new ValidationTestCases();

      //Act
      bool isValid = pizzaValidator.IsValidGetPizzas();

      //Assert
      Assert.True(isValid);
    }

    /// <summary>
    /// Validata pizzas description
    /// </summary>
    [Fact]
    public void ValidateValidToppings()
    {
      //Arrange
      var pizzaValidator = new ValidationTestCases();

      //Act
      bool isValid = pizzaValidator.IsValidGetToppings();

      //Assert
      Assert.True(isValid);
    }
  }
}
