using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OponeoBehavior.Specs.PageObjects;

public class CalculatorPageObject
{
    private readonly IWebDriver _driver;
    private const string Url = "https://specflowoss.github.io/Calculator-Demo/Calculator.html";

    public CalculatorPageObject(IWebDriver driver)
    {
        _driver = driver;
    }

    private IWebElement FirstNumber => _driver.FindElement(By.XPath("//*[@id=\"first-number\"]"));
    private IWebElement SecondNumber => _driver.FindElement(By.Id("second-number"));
    private IWebElement Result => _driver.FindElement(By.Name("result"));
    private IWebElement AddButton => _driver.FindElement(By.Id("add-button"));
    private IWebElement ResetButton => _driver.FindElement(By.Id("reset-button"));

    public void CheckCorrectUrl()
    {
        if (_driver.Url != Url)
        {
            _driver.Url = Url;
        }
    }
    
    public void SetFirstNumber(int number)
    {
        FirstNumber.Clear();
        FirstNumber.SendKeys(number.ToString());
    }
    
    public void SetSecondNumber(int number)
    {
        SecondNumber.Clear();
        SecondNumber.SendKeys(number.ToString());
    }
    
    public void ClickAddButton()
    {
        AddButton.Click();
    }
    
    public void ClickResetButton()
    {
        ResetButton.Click();
    }
    
    public int? GetResult()
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        
        for(var i = 0; i < 3; i++)
        {
            try
            {
                var stringResult = wait.Until(_ =>
                {
                    var res = Result.GetAttribute("value");
                    if (string.IsNullOrEmpty(res))
                    {
                        throw new Exception("Result is empty");
                    }

                    return res;
                });
                
                var isParsed = int.TryParse(stringResult, out var intResult);
                if (!isParsed)
                {
                    throw new Exception("Result is empty");
                }

                return intResult;
            }
            catch (NoSuchElementException)
            {
                Thread.Sleep(1000);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(1000);
            }
        }

        return null;
    }
}