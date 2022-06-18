using Microsoft.AspNetCore.Mvc;

namespace ResWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{    
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            decimal sum = Sum(firstNumber, secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }    

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubstraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(multi.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber) && IsGreaterThanZero(ConvertToDecimal(secondNumber)))
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(div.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("avg/{firstNumber}/{secondNumber}")]
    public IActionResult GetAverage(string firstNumber, string secondNumber)
    {
        if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
        {
            var avg = (Sum(firstNumber, secondNumber)) / 2;

            return Ok(avg.ToString());
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sqrt/{firstNumber}")]
    public IActionResult GetSquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sqr = Math.Sqrt(ConvertToDouble(firstNumber));

            return Ok(sqr.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal value;

        if (decimal.TryParse(strNumber, out value))
        {
            return value;
        }

        return 0;
    }

    private double ConvertToDouble(string strNumber)
    {
        double value;

        if (double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out value))
        {
            return value;
        }

        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;

        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);


        return isNumber;
    }

    private bool IsGreaterThanZero(decimal number)
    {        
        return number > 0;
    }

    private decimal Sum(string firstNumber, string secondNumber)
    {
        return ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
    }

}
